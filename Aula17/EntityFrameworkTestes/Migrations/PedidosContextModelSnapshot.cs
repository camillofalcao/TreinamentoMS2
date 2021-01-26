﻿// <auto-generated />
using EntityFrameworkTestes.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkTestes.Migrations
{
    [DbContext(typeof(PedidosContext))]
    partial class PedidosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EntityFrameworkTestes.Models.Cliente", b =>
                {
                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.Pedido", b =>
                {
                    b.Property<string>("PedidoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.PedidoItem", b =>
                {
                    b.Property<string>("PedidoItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PedidoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProdutoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("PedidoItemId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItens");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.Produto", b =>
                {
                    b.Property<string>("ProdutoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.Pedido", b =>
                {
                    b.HasOne("EntityFrameworkTestes.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.PedidoItem", b =>
                {
                    b.HasOne("EntityFrameworkTestes.Models.Pedido", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId");

                    b.HasOne("EntityFrameworkTestes.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("EntityFrameworkTestes.Models.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
