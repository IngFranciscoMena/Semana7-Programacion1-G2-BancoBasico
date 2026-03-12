namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniciarBaseDatos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Documento = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.String(),
                        ClienteId = c.Int(nullable: false),
                        TipoCuentaId = c.Int(nullable: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Byte(nullable: false),
                        FechaApertura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCuentas", t => t.TipoCuentaId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.TipoCuentaId);
            
            CreateTable(
                "dbo.TipoCuentas",
                c => new
                    {
                        TipoCuentaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Moneda = c.String(),
                        Activa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoCuentaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuentas", "TipoCuentaId", "dbo.TipoCuentas");
            DropForeignKey("dbo.Cuentas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Cuentas", new[] { "TipoCuentaId" });
            DropIndex("dbo.Cuentas", new[] { "ClienteId" });
            DropTable("dbo.TipoCuentas");
            DropTable("dbo.Cuentas");
            DropTable("dbo.Clientes");
        }
    }
}
