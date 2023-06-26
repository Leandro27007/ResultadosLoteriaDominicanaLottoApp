﻿// <auto-generated />
using System;
using LoteriaWebScrapy.API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoteriaWebScrapy.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230626211151_CambioTipoDeDatoFechaDeDateTimeADateOnly")]
    partial class CambioTipoDeDatoFechaDeDateTimeADateOnly
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("LoteriaWebScrapy.API.Datos.Modelos.Loteria", b =>
                {
                    b.Property<string>("IdLoteria")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreLoteria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdLoteria");

                    b.ToTable("loteria");

                    b.HasData(
                        new
                        {
                            IdLoteria = "GanaMas",
                            NombreLoteria = "GanaMas"
                        },
                        new
                        {
                            IdLoteria = "LoteriaNacional",
                            NombreLoteria = "LoteriaNacional"
                        },
                        new
                        {
                            IdLoteria = "Pega3Mas",
                            NombreLoteria = "Pega3Mas"
                        },
                        new
                        {
                            IdLoteria = "QuinielaLeidsa",
                            NombreLoteria = "QuinielaLeidsa"
                        },
                        new
                        {
                            IdLoteria = "QuinielaReal",
                            NombreLoteria = "QuinielaReal"
                        },
                        new
                        {
                            IdLoteria = "LaPrimera",
                            NombreLoteria = "LaPrimera"
                        });
                });

            modelBuilder.Entity("LoteriaWebScrapy.API.Datos.Modelos.ResultadoQuiniela", b =>
                {
                    b.Property<string>("IdResultado")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FechaResultado")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdLoteria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LoteriaIdLoteria")
                        .HasColumnType("TEXT");

                    b.Property<string>("Primera")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Segunda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tercera")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdResultado");

                    b.HasIndex("LoteriaIdLoteria");

                    b.ToTable("resultadoQuiniela");
                });

            modelBuilder.Entity("LoteriaWebScrapy.API.Datos.Modelos.ResultadoQuiniela", b =>
                {
                    b.HasOne("LoteriaWebScrapy.API.Datos.Modelos.Loteria", "Loteria")
                        .WithMany("ResultadosQuiniela")
                        .HasForeignKey("LoteriaIdLoteria");

                    b.Navigation("Loteria");
                });

            modelBuilder.Entity("LoteriaWebScrapy.API.Datos.Modelos.Loteria", b =>
                {
                    b.Navigation("ResultadosQuiniela");
                });
#pragma warning restore 612, 618
        }
    }
}
