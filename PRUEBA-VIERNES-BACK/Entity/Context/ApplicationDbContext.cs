﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entity.Models;
using Entity.Models.Pizzeria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<EstadoPedido> EstadosPedidos { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }





        /// <summary>
        /// Configura los modelos de la base de datos aplicando configuraciones desde ensamblados.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Configura opciones adicionales del contexto, como el registro de datos sensibles.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de configuración del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Otras configuraciones adicionales pueden ir aquí
        }

        /// <summary>
        /// Configura convenciones de tipos de datos, estableciendo la precisión por defecto de los valores decimales.
        /// </summary>
        /// <param name="configurationBuilder">Constructor de configuración de modelos.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos, asegurando la auditoría antes de persistir los datos.
        /// </summary>
        /// <returns>Número de filas afectadas.</returns>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de manera asíncrona, asegurando la auditoría antes de la persistencia.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indica si se deben aceptar todos los cambios en caso de éxito.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación.</param>
        /// <returns>Número de filas afectadas de forma asíncrona.</returns>
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //EnsureAudit();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve una colección de resultados de tipo genérico.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Una colección de objetos del tipo especificado.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve un solo resultado o el valor predeterminado si no hay resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Un objeto del tipo especificado o su valor predeterminado.</returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        /// <summary>
        /// Método interno para garantizar la auditoría de los cambios en las entidades.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        /// <summary>
        /// Estructura para ejecutar comandos SQL con Dapper en Entity Framework Core.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
            /// <summary>
            /// Constructor del comando Dapper.
            /// </summary>
            /// <param name="context">Contexto de la base de datos.</param>
            /// <param name="text">Consulta SQL.</param>
            /// <param name="parameters">Parámetros opcionales.</param>
            /// <param name="timeout">Tiempo de espera opcional.</param>
            /// <param name="type">Tipo de comando SQL opcional.</param>
            /// <param name="ct">Token de cancelación.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            /// <summary>
            /// Define los parámetros del comando SQL.
            /// </summary>
            public CommandDefinition Definition { get; }

            /// <summary>
            /// Método para liberar los recursos.
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}

