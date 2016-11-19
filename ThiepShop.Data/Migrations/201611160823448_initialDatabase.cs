namespace ThiepShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAgency",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Tag = c.String(nullable: false, maxLength: 200),
                        idMenu = c.Int(nullable: false),
                        Images = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        People = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Tabs = c.String(nullable: false, maxLength: 500),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                        GroupAgency_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GroupAgency", t => t.GroupAgency_id)
                .Index(t => t.GroupAgency_id);
            
            CreateTable(
                "dbo.GroupAgency",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Level = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblBanks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 200),
                        NameBank = c.String(nullable: false, maxLength: 200),
                        NumberBank = c.String(nullable: false, maxLength: 100),
                        Images = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblColorProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CompetitorHomes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CodeProduct = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblCompetitorLink",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idHomes = c.Int(nullable: false),
                        idCompetitor = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CompetitorHomes", t => t.idHomes, cascadeDelete: true)
                .ForeignKey("dbo.tblCompetitor", t => t.idCompetitor, cascadeDelete: true)
                .Index(t => t.idHomes)
                .Index(t => t.idCompetitor);
            
            CreateTable(
                "dbo.tblCompetitor",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 200),
                        Website = c.String(nullable: false, maxLength: 300),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConfig",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Desciption = c.String(nullable: false, maxLength: 500),
                        Keywords = c.String(nullable: false, maxLength: 500),
                        Logo = c.String(nullable: false, maxLength: 200),
                        Favicon = c.String(nullable: false, maxLength: 200),
                        Popup = c.Boolean(nullable: false),
                        PopupSupport = c.Boolean(nullable: false),
                        Content = c.String(storeType: "ntext"),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 200),
                        MobileIN = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        Holine = c.String(nullable: false, maxLength: 100),
                        HolineIN = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Slogan = c.String(nullable: false, maxLength: 200),
                        Authorship = c.String(nullable: false, maxLength: 100),
                        FanpageFaceBook = c.String(nullable: false, maxLength: 200),
                        FanpageGoogle = c.String(nullable: false, maxLength: 200),
                        FanpageYoutube = c.String(nullable: false, maxLength: 200),
                        AppFaceBook = c.String(nullable: false, maxLength: 100),
                        Analytics = c.String(nullable: false, maxLength: 200),
                        GoogleMaster = c.String(nullable: false, maxLength: 500),
                        GeoMeta = c.String(nullable: false, maxLength: 1000),
                        DMCA = c.String(nullable: false, maxLength: 200),
                        CodeChat = c.String(nullable: false, maxLength: 1000),
                        BCT = c.String(nullable: false, maxLength: 200),
                        BNI = c.String(nullable: false, maxLength: 200),
                        SKH = c.String(nullable: false, maxLength: 200),
                        Coppy = c.Boolean(nullable: false),
                        Social = c.Boolean(nullable: false),
                        UserEmail = c.String(nullable: false, maxLength: 100),
                        PassEmail = c.String(nullable: false, maxLength: 100),
                        Host = c.String(nullable: false, maxLength: 100),
                        Port = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 100),
                        TimeOut = c.String(nullable: false, maxLength: 100),
                        language = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblConnectColorProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idColor = c.Int(nullable: false),
                        idPro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblColorProduct", t => t.idColor, cascadeDelete: true)
                .ForeignKey("dbo.tblProduct", t => t.idPro, cascadeDelete: true)
                .Index(t => t.idColor)
                .Index(t => t.idPro);
            
            CreateTable(
                "dbo.tblProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(),
                        Code = c.String(maxLength: 100, unicode: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        Keyword = c.String(maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Info = c.String(storeType: "ntext"),
                        Parameter = c.String(storeType: "ntext"),
                        Tag = c.String(maxLength: 500),
                        ImageLinkThumb = c.String(maxLength: 200),
                        ImageLinkDetail = c.String(maxLength: 200),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Int(nullable: false),
                        PriceString = c.String(maxLength: 700),
                        PriceSale = c.Int(nullable: false),
                        PriceSaleString = c.String(maxLength: 700),
                        Vat = c.Boolean(),
                        Warranty = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Transport = c.Boolean(),
                        Access = c.String(maxLength: 300),
                        Sale = c.String(maxLength: 300),
                        Note = c.String(maxLength: 300),
                        Size = c.String(maxLength: 200),
                        ImageSale = c.String(maxLength: 200),
                        Status = c.Boolean(),
                        ProductSale = c.Boolean(),
                        Priority = c.Boolean(),
                        New = c.Boolean(),
                        ViewHomes = c.Boolean(),
                        Visit = c.Int(),
                        Tags = c.String(maxLength: 500),
                        idVideo = c.Int(),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblGroupProduct", t => t.idCate)
                .Index(t => t.idCate);
            
            CreateTable(
                "dbo.tblGroupProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Title = c.String(maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Tag = c.String(maxLength: 200),
                        Level = c.Int(nullable: false),
                        Priority = c.Boolean(nullable: false),
                        Images = c.String(maxLength: 200),
                        Background = c.String(maxLength: 200),
                        iCon = c.String(maxLength: 200),
                        Color = c.String(maxLength: 100),
                        Alias = c.String(maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectCriteria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCre = c.Int(nullable: false),
                        idpd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblCriteria", t => t.idCre, cascadeDelete: true)
                .ForeignKey("dbo.tblProduct", t => t.idpd, cascadeDelete: true)
                .Index(t => t.idCre)
                .Index(t => t.idpd);
            
            CreateTable(
                "dbo.tblCriteria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(nullable: false),
                        Priority = c.Boolean(nullable: false),
                        Style = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectGroup",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(nullable: false),
                        idg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectImages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idImg = c.Int(nullable: false),
                        idCate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectMenuProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idManu = c.Int(nullable: false),
                        idCate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectNews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idNew = c.Int(nullable: false),
                        idCate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblConnectWebs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idWeb = c.Int(nullable: false),
                        idCate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblContact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Content = c.String(storeType: "ntext"),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblError",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblFiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        File = c.String(nullable: false, maxLength: 200),
                        Images = c.String(nullable: false, maxLength: 200),
                        Cate = c.Int(nullable: false),
                        idp = c.Int(nullable: false),
                        idg = c.Int(nullable: false),
                        Tag = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblGroupChild",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        idParent = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Priority = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblGroupImage",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblGroupNews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Index = c.Boolean(nullable: false),
                        Images = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblHistoryLogin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Task = c.String(nullable: false, maxLength: 100),
                        idUser = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblHotline",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        Holine = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblImageProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idProduct = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        Images = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblImages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 200),
                        Url = c.String(nullable: false, maxLength: 200),
                        Link = c.Boolean(nullable: false),
                        Color = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblGroupImage", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tblInfoCriteria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCri = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Url = c.String(nullable: false, maxLength: 200),
                        type = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblManufactures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Images = c.String(nullable: false, maxLength: 200),
                        Keywork = c.String(nullable: false, maxLength: 500),
                        Title = c.String(nullable: false, maxLength: 200),
                        Priority = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblMaps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblModule",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblNews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 500),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Images = c.String(nullable: false, maxLength: 200),
                        ViewHomes = c.Boolean(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Tabs = c.String(nullable: false, maxLength: 500),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblGroupNews", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tblOrderDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idOrder = c.Int(nullable: false),
                        idProduct = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Quantily = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        SumPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblOrder",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        Mobiles = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        Name1 = c.String(nullable: false, maxLength: 200),
                        Address1 = c.String(nullable: false, maxLength: 200),
                        Mobiles1 = c.String(nullable: false, maxLength: 100),
                        Email1 = c.String(nullable: false, maxLength: 100),
                        NameCP = c.String(nullable: false, maxLength: 200),
                        AddressCP = c.String(nullable: false, maxLength: 200),
                        MST = c.String(nullable: false, maxLength: 100),
                        TypePay = c.Int(nullable: false),
                        TypeTransport = c.Int(nullable: false),
                        DateByy = c.DateTime(nullable: false),
                        idUser = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblPartner",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 200),
                        Hotline = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblProductCheck",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCate = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100, unicode: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Info = c.String(storeType: "ntext"),
                        Parameter = c.String(storeType: "ntext"),
                        Tag = c.String(nullable: false, maxLength: 500),
                        ImageLinkThumb = c.String(nullable: false, maxLength: 200),
                        ImageLinkDetail = c.String(nullable: false, maxLength: 200),
                        Price = c.Single(nullable: false),
                        PriceString = c.String(nullable: false, maxLength: 700),
                        PriceSale = c.Single(nullable: false),
                        PriceSaleString = c.String(nullable: false, maxLength: 700),
                        Vat = c.Boolean(nullable: false),
                        Warranty = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Transport = c.Boolean(nullable: false),
                        Access = c.String(nullable: false, maxLength: 300),
                        Sale = c.String(nullable: false, maxLength: 300),
                        Note = c.String(nullable: false, maxLength: 300),
                        Size = c.String(nullable: false, maxLength: 200),
                        ImageSale = c.String(nullable: false, maxLength: 200),
                        Status = c.Boolean(nullable: false),
                        ProductSale = c.Boolean(nullable: false),
                        Priority = c.Boolean(nullable: false),
                        New = c.Boolean(nullable: false),
                        ViewHomes = c.Boolean(nullable: false),
                        Visit = c.Int(nullable: false),
                        Tabs = c.String(nullable: false, maxLength: 500),
                        idVideo = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblGroupProduct", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tblProductChecl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idSyn = c.Int(nullable: false),
                        idpd = c.Int(nullable: false),
                        Content = c.String(storeType: "ntext"),
                        Parameter = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblProductSale",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 500),
                        CodeOne = c.String(nullable: false, maxLength: 1000),
                        CodeTrue = c.String(nullable: false, maxLength: 1000),
                        CodeSale = c.String(nullable: false, maxLength: 1000),
                        Content = c.String(storeType: "ntext"),
                        Slogan = c.String(nullable: false, maxLength: 300),
                        TextRun = c.String(nullable: false, maxLength: 1000),
                        StartSale = c.DateTime(nullable: false),
                        StopSale = c.DateTime(nullable: false),
                        ImageBanner = c.String(nullable: false, maxLength: 200),
                        ImageSale = c.String(nullable: false, maxLength: 200),
                        ImageThumb = c.String(nullable: false, maxLength: 200),
                        Tag = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblProductSyn",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100, unicode: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Info = c.String(storeType: "ntext"),
                        Parameter = c.String(storeType: "ntext"),
                        Tag = c.String(nullable: false, maxLength: 500),
                        ImageLinkThumb = c.String(nullable: false, maxLength: 200),
                        ImageLinkDetail = c.String(nullable: false, maxLength: 200),
                        Price = c.Single(nullable: false),
                        PriceString = c.String(nullable: false, maxLength: 700),
                        PriceSale = c.Single(nullable: false),
                        PriceSaleString = c.String(nullable: false, maxLength: 700),
                        Vat = c.Boolean(nullable: false),
                        Warranty = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Transport = c.Boolean(nullable: false),
                        Access = c.String(nullable: false, maxLength: 300),
                        Sale = c.String(nullable: false, maxLength: 300),
                        Note = c.String(nullable: false, maxLength: 300),
                        Size = c.String(nullable: false, maxLength: 200),
                        ImageSale = c.String(nullable: false, maxLength: 200),
                        Status = c.Boolean(nullable: false),
                        ProductSale = c.Boolean(nullable: false),
                        Priority = c.Boolean(nullable: false),
                        New = c.Boolean(nullable: false),
                        ViewHomes = c.Boolean(nullable: false),
                        Visit = c.Int(nullable: false),
                        Tabs = c.String(nullable: false, maxLength: 500),
                        idVideo = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblProductTags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idProduct = c.Int(nullable: false),
                        idTags = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblRegister",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        idCate = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblRight",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idModule = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblSupport",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Yahoo = c.String(nullable: false, maxLength: 100),
                        Skyper = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Mission = c.String(nullable: false, maxLength: 100),
                        Images = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblTags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblUrl",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 200),
                        Rel = c.Boolean(nullable: false),
                        idCate = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 200),
                        Gender = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        idModule = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblVideo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(nullable: false, maxLength: 500),
                        AutoPlay = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        idUser = c.Int(nullable: false),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblWeb",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 200),
                        Ord = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProductCheck", "id", "dbo.tblGroupProduct");
            DropForeignKey("dbo.tblNews", "id", "dbo.tblGroupNews");
            DropForeignKey("dbo.tblImages", "id", "dbo.tblGroupImage");
            DropForeignKey("dbo.tblConnectCriteria", "idpd", "dbo.tblProduct");
            DropForeignKey("dbo.tblConnectCriteria", "idCre", "dbo.tblCriteria");
            DropForeignKey("dbo.tblConnectColorProduct", "idPro", "dbo.tblProduct");
            DropForeignKey("dbo.tblProduct", "idCate", "dbo.tblGroupProduct");
            DropForeignKey("dbo.tblConnectColorProduct", "idColor", "dbo.tblColorProduct");
            DropForeignKey("dbo.tblCompetitorLink", "idCompetitor", "dbo.tblCompetitor");
            DropForeignKey("dbo.tblCompetitorLink", "idHomes", "dbo.CompetitorHomes");
            DropForeignKey("dbo.tblAgency", "GroupAgency_id", "dbo.GroupAgency");
            DropIndex("dbo.tblProductCheck", new[] { "id" });
            DropIndex("dbo.tblNews", new[] { "id" });
            DropIndex("dbo.tblImages", new[] { "id" });
            DropIndex("dbo.tblConnectCriteria", new[] { "idpd" });
            DropIndex("dbo.tblConnectCriteria", new[] { "idCre" });
            DropIndex("dbo.tblProduct", new[] { "idCate" });
            DropIndex("dbo.tblConnectColorProduct", new[] { "idPro" });
            DropIndex("dbo.tblConnectColorProduct", new[] { "idColor" });
            DropIndex("dbo.tblCompetitorLink", new[] { "idCompetitor" });
            DropIndex("dbo.tblCompetitorLink", new[] { "idHomes" });
            DropIndex("dbo.tblAgency", new[] { "GroupAgency_id" });
            DropTable("dbo.tblWeb");
            DropTable("dbo.tblVideo");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblUrl");
            DropTable("dbo.tblTags");
            DropTable("dbo.tblSupport");
            DropTable("dbo.tblRight");
            DropTable("dbo.tblRegister");
            DropTable("dbo.tblProductTags");
            DropTable("dbo.tblProductSyn");
            DropTable("dbo.tblProductSale");
            DropTable("dbo.tblProductChecl");
            DropTable("dbo.tblProductCheck");
            DropTable("dbo.tblPartner");
            DropTable("dbo.tblOrder");
            DropTable("dbo.tblOrderDetail");
            DropTable("dbo.tblNews");
            DropTable("dbo.tblModule");
            DropTable("dbo.tblMaps");
            DropTable("dbo.tblManufactures");
            DropTable("dbo.tblInfoCriteria");
            DropTable("dbo.tblImages");
            DropTable("dbo.tblImageProduct");
            DropTable("dbo.tblHotline");
            DropTable("dbo.tblHistoryLogin");
            DropTable("dbo.tblGroupNews");
            DropTable("dbo.tblGroupImage");
            DropTable("dbo.tblGroupChild");
            DropTable("dbo.tblFiles");
            DropTable("dbo.tblError");
            DropTable("dbo.tblContact");
            DropTable("dbo.tblConnectWebs");
            DropTable("dbo.tblConnectNews");
            DropTable("dbo.tblConnectMenuProduct");
            DropTable("dbo.tblConnectImages");
            DropTable("dbo.tblConnectGroup");
            DropTable("dbo.tblCriteria");
            DropTable("dbo.tblConnectCriteria");
            DropTable("dbo.tblGroupProduct");
            DropTable("dbo.tblProduct");
            DropTable("dbo.tblConnectColorProduct");
            DropTable("dbo.tblConfig");
            DropTable("dbo.tblCompetitor");
            DropTable("dbo.tblCompetitorLink");
            DropTable("dbo.CompetitorHomes");
            DropTable("dbo.tblColorProduct");
            DropTable("dbo.tblBanks");
            DropTable("dbo.GroupAgency");
            DropTable("dbo.tblAgency");
        }
    }
}
