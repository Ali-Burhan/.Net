CREATE TABLE [dbo].[tblAccountActivity](

	[AccountActivityID] [int] IDENTITY(1,1) NOT NULL,

	[Name] [nvarchar](100) NOT NULL,

 CONSTRAINT [PK_tblAccountActivity] PRIMARY KEY CLUSTERED 

(

	[AccountActivityID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblAccountControl]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblAccountControl](

	[AccountControlID] [int] IDENTITY(1,1) NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[AccountHeadID] [int] NOT NULL,

	[AccountControlName] [varchar](50) NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblAccountControl] PRIMARY KEY CLUSTERED 

(

	[AccountControlID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblAccountHead]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblAccountHead](

	[AccountHeadID] [int] IDENTITY(1,1) NOT NULL,

	[AccountHeadName] [varchar](50) NOT NULL,

	[Code] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblAccountHead] PRIMARY KEY CLUSTERED 

(

	[AccountHeadID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblAccountSetting]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblAccountSetting](

	[AccountSettingID] [int] IDENTITY(1,1) NOT NULL,

	[AccountHeadID] [int] NOT NULL,

	[AccountControlID] [int] NOT NULL,

	[AccountSubControlID] [int] NOT NULL CONSTRAINT [DF_tblAccountSetting_AccountSubControlID]  DEFAULT ((0)),

	[AccountActivityID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

 CONSTRAINT [PK_tblAccountSetting] PRIMARY KEY CLUSTERED 

(

	[AccountSettingID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblAccountSubControl]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblAccountSubControl](

	[AccountSubControlID] [int] IDENTITY(1,1) NOT NULL,

	[AccountHeadID] [int] NOT NULL,

	[AccountControlID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[AccountSubControlName] [varchar](50) NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblAccountSubControl] PRIMARY KEY CLUSTERED 

(

	[AccountSubControlID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblAgent]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblAgent](

	[AgentID] [int] NOT NULL,

	[UserID] [int] NULL,

	[AgentName] [nvarchar](250) NOT NULL,

	[ContactNo] [nvarchar](50) NOT NULL,

	[PhoneNo] [nvarchar](50) NULL,

	[Fax] [nvarchar](50) NULL,

	[Email] [nvarchar](250) NOT NULL,

	[Agent_Commission] [float] NOT NULL,

	[CountryID] [int] NOT NULL,

	[StateID] [int] NOT NULL,

	[CityID] [int] NOT NULL,

	[BranchID] [int] NOT NULL

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblBranch]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblBranch](

	[BranchID] [int] IDENTITY(1,1) NOT NULL,

	[BranchTypeID] [int] NOT NULL,

	[BranchName] [varchar](50) NOT NULL,

	[BranchContact] [nvarchar](50) NOT NULL,

	[BranchAddress] [varchar](300) NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BrchID] [int] NULL,

 CONSTRAINT [PK_tblBranch] PRIMARY KEY CLUSTERED 

(

	[BranchID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblBranchType]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblBranchType](

	[BranchTypeID] [int] IDENTITY(1,1) NOT NULL,

	[BranchType] [varchar](50) NOT NULL,

 CONSTRAINT [PK_tblBranchType] PRIMARY KEY CLUSTERED 

(

	[BranchTypeID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblCategory]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblCategory](

	[CategoryID] [int] IDENTITY(1,1) NOT NULL,

	[categoryName] [varchar](50) NOT NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 

(

	[CategoryID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblCity]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCity](

	[CityID] [int] IDENTITY(1,1) NOT NULL,

	[CityName] [nvarchar](150) NOT NULL,

	[StateID] [int] NOT NULL,

	[CountryID] [int] NOT NULL,

	[CityZone] [nvarchar](150) NOT NULL,

	[CityCode] [nvarchar](50) NULL,

	[CityPinCode] [nvarchar](50) NULL,

 CONSTRAINT [PK_tblCity] PRIMARY KEY CLUSTERED 

(

	[CityID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCompany]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCompany](

	[CompanyID] [int] IDENTITY(1,1) NOT NULL,

	[Name] [nvarchar](200) NOT NULL,

	[Logo] [nvarchar](200) NULL,

 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 

(

	[CompanyID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCountry]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCountry](

	[CountryID] [int] IDENTITY(1,1) NOT NULL,

	[CountryName] [nvarchar](250) NOT NULL,

	[Photo] [nvarchar](250) NULL,

	[Title] [nvarchar](50) NOT NULL,

	[Keyword] [nvarchar](50) NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED 

(

	[CountryID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblCustomer](

	[CustomerID] [int] IDENTITY(1,1) NOT NULL,

	[Customername] [varchar](150) NOT NULL,

	[CustomerContact] [nvarchar](150) NOT NULL,

	[CustomerArea] [varchar](50) NOT NULL,

	[CustomerAddress] [varchar](300) NOT NULL,

	[Description] [varchar](300) NOT NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 

(

	[CustomerID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblCustomerInvoice]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblCustomerInvoice](

	[CustomerInvoiceID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[Title] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[InvoiceDate] [date] NOT NULL,

	[Description] [varchar](500) NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblCustomerInvoice] PRIMARY KEY CLUSTERED 

(

	[CustomerInvoiceID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblCustomerInvoiceDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCustomerInvoiceDetail](

	[CustomerInvoiceDetailID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerInvoiceID] [int] NOT NULL,

	[ProductID] [int] NOT NULL,

	[SaleQuantity] [int] NOT NULL,

	[SaleUnitPrice] [float] NOT NULL,

 CONSTRAINT [PK_tblCustomerInvoiceDetail] PRIMARY KEY CLUSTERED 

(

	[CustomerInvoiceDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCustomerPayment]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCustomerPayment](

	[CustomerPaymentID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerID] [int] NOT NULL,

	[CustomerInvoiceID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[invoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[PaidAmount] [float] NOT NULL,

	[RemainingBalance] [float] NOT NULL,

	[UserID] [int] NOT NULL,

	[InvoiceDate] [date] NULL,

 CONSTRAINT [PK_tblCustomerPayment] PRIMARY KEY CLUSTERED 

(

	[CustomerPaymentID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCustomerReturnInvoice]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCustomerReturnInvoice](

	[CustomerReturnInvoiceID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerInvoiceID] [int] NOT NULL,

	[CustomerID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[InvoiceDate] [date] NOT NULL,

	[Description] [nvarchar](500) NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblCustomerReturnInvoice] PRIMARY KEY CLUSTERED 

(

	[CustomerReturnInvoiceID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCustomerReturnInvoiceDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCustomerReturnInvoiceDetail](

	[CustomerReturnInvoiceDetailID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerInvoiceDetailID] [int] NOT NULL,

	[CustomerInvoiceID] [int] NOT NULL,

	[CustomerReturnInvoiceID] [int] NOT NULL,

	[ProductID] [int] NOT NULL,

	[SaleReturnQuantity] [int] NOT NULL,

	[SaleReturnUnitPrice] [float] NOT NULL,

 CONSTRAINT [PK_tblCustomerReturnInvoiceDetail] PRIMARY KEY CLUSTERED 

(

	[CustomerReturnInvoiceDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblCustomerReturnPayment]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblCustomerReturnPayment](

	[CustomerReturnPaymentID] [int] IDENTITY(1,1) NOT NULL,

	[CustomerReturnInvoiceID] [int] NOT NULL,

	[CustomerID] [int] NOT NULL,

	[CustomerInvoiceID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[PaidAmount] [float] NOT NULL,

	[RemainingBalance] [float] NOT NULL,

	[UserID] [int] NOT NULL,

	[InvoiceDate] [date] NULL,

 CONSTRAINT [PK_tblCustomerReturnPayment] PRIMARY KEY CLUSTERED 

(

	[CustomerReturnPaymentID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[tblEmployee](

	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,

	[Name] [nvarchar](150) NOT NULL,

	[ContactNo] [nvarchar](50) NOT NULL,

	[Photo] [nvarchar](150) NULL,

	[Email] [nvarchar](150) NOT NULL,

	[Address] [varchar](300) NOT NULL,

	[CNIC] [nvarchar](50) NOT NULL,

	[Designation] [nvarchar](150) NOT NULL,

	[Description] [nvarchar](500) NOT NULL,

	[MonthlySalary] [float] NOT NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[UserID] [int] NULL,

 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 

(

	[EmployeeID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[tblFinancialYear]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblFinancialYear](

	[FinancialYearID] [int] IDENTITY(1,1) NOT NULL,

	[UserID] [int] NOT NULL,

	[FinancialYear] [nvarchar](150) NOT NULL,

	[StartDate] [date] NOT NULL,

	[EndDate] [date] NOT NULL,

	[IsActive] [bit] NOT NULL CONSTRAINT [DF_tblFinancialYear_IsActive]  DEFAULT ((0)),

 CONSTRAINT [PK_tblFinancialYear] PRIMARY KEY CLUSTERED 

(

	[FinancialYearID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblPayroll]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblPayroll](

	[PayrollID] [int] IDENTITY(1,1) NOT NULL,

	[EmployeeID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[TransferAmount] [float] NOT NULL,

	[PayrollInvoiceNo] [nvarchar](150) NOT NULL,

	[PaymentDate] [date] NOT NULL,

	[SalaryMonth] [nvarchar](50) NOT NULL,

	[SalaryYear] [nvarchar](50) NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblPayroll] PRIMARY KEY CLUSTERED 

(

	[PayrollID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblPurchaseCartDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblPurchaseCartDetail](

	[PurchaseCartDetailID] [int] IDENTITY(1,1) NOT NULL,

	[ProductID] [int] NOT NULL,

	[PurchaseQuantity] [int] NOT NULL,

	[purchaseUnitPrice] [float] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblPurchaseCartDetailTable] PRIMARY KEY CLUSTERED 

(

	[PurchaseCartDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSaleCartDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSaleCartDetail](

	[SaleCartDetailID] [int] IDENTITY(1,1) NOT NULL,

	[ProductID] [int] NOT NULL,

	[SaleQuantity] [int] NOT NULL,

	[SaleUnitPrice] [float] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblSaleCartDetail] PRIMARY KEY CLUSTERED 

(

	[SaleCartDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblState]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblState](

	[StateID] [int] IDENTITY(1,1) NOT NULL,

	[StateName] [nvarchar](250) NOT NULL,

	[CountryID] [int] NOT NULL,

 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 

(

	[StateID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblStock]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblStock](

	[ProductID] [int] IDENTITY(1,1) NOT NULL,

	[CategoryID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[ProductName] [nvarchar](80) NOT NULL,

	[Quantity] [int] NOT NULL,

	[SaleUnitPrice] [float] NOT NULL,

	[CurrentPurchaseUnitPrice] [float] NOT NULL,

	[ExpiryDate] [date] NOT NULL,

	[Manufacture] [date] NOT NULL,

	[StockTreshHoldQuantity] [int] NOT NULL,

	[Description] [nvarchar](300) NULL,

	[UserID] [int] NOT NULL,

	[IsActive] [bit] NOT NULL CONSTRAINT [DF_tblStock_IsActive]  DEFAULT ((0)),

 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 

(

	[ProductID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplier]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplier](

	[SupplierID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierName] [nvarchar](150) NOT NULL,

	[SupplierConatctNo] [nvarchar](20) NOT NULL,

	[SupplierAddress] [nvarchar](150) NULL,

	[SupplierEmail] [nvarchar](150) NULL,

	[Discription] [nvarchar](300) NULL,

	[BranchID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED 

(

	[SupplierID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierInvoice]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierInvoice](

	[SupplierInvoiceID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[InvoiceDate] [date] NOT NULL,

	[Description] [nvarchar](150) NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblSupplierInvoiceTable] PRIMARY KEY CLUSTERED 

(

	[SupplierInvoiceID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierInvoiceDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierInvoiceDetail](

	[SupplierInvoiceDetailID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierInvoiceID] [int] NOT NULL,

	[ProductID] [int] NOT NULL,

	[PurchaseQuantity] [int] NOT NULL,

	[purchaseUnitPrice] [float] NOT NULL,

 CONSTRAINT [PK_tblSupplierInvoiceDetailTable] PRIMARY KEY CLUSTERED 

(

	[SupplierInvoiceDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierPayment]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierPayment](

	[SupplierPaymentID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierID] [int] NOT NULL,

	[SupplierInvoiceID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[PaymentAmount] [float] NOT NULL,

	[RemainingBalance] [float] NOT NULL,

	[UserID] [int] NOT NULL,

	[InvoiceDate] [date] NULL,

 CONSTRAINT [PK_tblSupplierPayment] PRIMARY KEY CLUSTERED 

(

	[SupplierPaymentID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierReturnInvoice]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierReturnInvoice](

	[SupplierReturnInvoiceID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierInvoiceID] [int] NOT NULL,

	[SupplierID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](100) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[InvoiceDate] [date] NOT NULL,

	[Description] [nvarchar](500) NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_tblSupplierReturnInvoice] PRIMARY KEY CLUSTERED 

(

	[SupplierReturnInvoiceID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierReturnInvoiceDetail]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierReturnInvoiceDetail](

	[SupplierReturnInvoiceDetailID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierInvoiceID] [int] NOT NULL,

	[SupplierReturnInvoiceID] [int] NOT NULL,

	[SupplierInvoiceDetailID] [int] NOT NULL,

	[ProductID] [int] NOT NULL,

	[PurchaseReturnQuantity] [int] NOT NULL,

	[PurchaseReturnUnitPrice] [float] NOT NULL,

 CONSTRAINT [PK_tblSupplierReturnInvoiceDetail] PRIMARY KEY CLUSTERED 

(

	[SupplierReturnInvoiceDetailID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblSupplierReturnPayment]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblSupplierReturnPayment](

	[SupplierReturnPaymentID] [int] IDENTITY(1,1) NOT NULL,

	[SupplierReturnInvoiceID] [int] NOT NULL,

	[SupplierInvoiceID] [int] NOT NULL,

	[SupplierID] [int] NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[TotalAmount] [float] NOT NULL,

	[PaymentAmount] [float] NOT NULL,

	[RemainingBalance] [float] NOT NULL,

	[UserID] [int] NOT NULL,

	[InvoiceDate] [date] NULL,

 CONSTRAINT [PK_tblSupplierReturnPayment] PRIMARY KEY CLUSTERED 

(

	[SupplierReturnPaymentID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblTransaction]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblTransaction](

	[TransactionID] [int] IDENTITY(1,1) NOT NULL,

	[FinancialYearID] [int] NOT NULL,

	[AccountHeadID] [int] NOT NULL,

	[AccountControlID] [int] NOT NULL,

	[AccountSubControlID] [int] NOT NULL,

	[InvoiceNo] [nvarchar](150) NOT NULL,

	[CompanyID] [int] NOT NULL,

	[BranchID] [int] NOT NULL,

	[Credit] [float] NOT NULL,

	[Debit] [float] NOT NULL,

	[TransectionDate] [datetime] NOT NULL,

	[TransectionTitle] [nvarchar](150) NOT NULL,

	[UserID] [int] NOT NULL,

 CONSTRAINT [PK_TransectionTable] PRIMARY KEY CLUSTERED 

(

	[TransactionID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblUser](

	[UserID] [int] IDENTITY(1,1) NOT NULL,

	[UserTypeID] [int] NOT NULL,

	[FullName] [nvarchar](150) NOT NULL,

	[Email] [nvarchar](150) NOT NULL,

	[ContactNo] [nvarchar](20) NOT NULL,

	[UserName] [nvarchar](150) NOT NULL,

	[Password] [nvarchar](150) NOT NULL,

	[IsActive] [bit] NOT NULL CONSTRAINT [DF_tblUser_IsActive]  DEFAULT ((0)),

 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 

(

	[UserID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  Table [dbo].[tblUserType]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[tblUserType](

	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,

	[UserType] [nvarchar](150) NOT NULL,

 CONSTRAINT [PK_tblUserType] PRIMARY KEY CLUSTERED 

(

	[UserTypeID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]



GO

/****** Object:  View [dbo].[v_Transaction]    Script Date: 09/08/2021 1:01:43 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE VIEW [dbo].[v_Transaction]

AS

SELECT        dbo.tblTransaction.TransactionID, dbo.tblTransaction.FinancialYearID, dbo.tblTransaction.AccountHeadID, dbo.tblTransaction.AccountControlID, dbo.tblTransaction.AccountSubControlID, 

                         dbo.tblAccountHead.AccountHeadName + '-/-' + dbo.tblAccountControl.AccountControlName + '-/-' + dbo.tblAccountSubControl.AccountSubControlName AS AccountTitle, dbo.tblTransaction.InvoiceNo, 

                         dbo.tblTransaction.CompanyID, dbo.tblTransaction.BranchID, dbo.tblTransaction.Debit, dbo.tblTransaction.Credit, dbo.tblTransaction.TransectionDate, dbo.tblTransaction.TransectionTitle, dbo.tblTransaction.UserID

FROM            dbo.tblTransaction INNER JOIN

                         dbo.tblAccountSubControl ON dbo.tblTransaction.AccountSubControlID = dbo.tblAccountSubControl.AccountSubControlID INNER JOIN

                         dbo.tblAccountHead ON dbo.tblTransaction.AccountHeadID = dbo.tblAccountHead.AccountHeadID AND dbo.tblTransaction.AccountHeadID = dbo.tblAccountHead.AccountHeadID INNER JOIN

                         dbo.tblAccountControl ON dbo.tblTransaction.AccountControlID = dbo.tblAccountControl.AccountControlID



GO

ALTER TABLE [dbo].[tblAccountControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountControl_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblAccountControl] CHECK CONSTRAINT [FK_tblAccountControl_tblBranch]

GO

ALTER TABLE [dbo].[tblAccountControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountControl_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblAccountControl] CHECK CONSTRAINT [FK_tblAccountControl_tblCompany]

GO

ALTER TABLE [dbo].[tblAccountControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountControl_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblAccountControl] CHECK CONSTRAINT [FK_tblAccountControl_tblUser]

GO

ALTER TABLE [dbo].[tblAccountHead]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountHead_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblAccountHead] CHECK CONSTRAINT [FK_tblAccountHead_tblUser]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblAccountActivity] FOREIGN KEY([AccountActivityID])

REFERENCES [dbo].[tblAccountActivity] ([AccountActivityID])

GO

ALTER TABLE [dbo].[tblAccountSetting] CHECK CONSTRAINT [FK_tblAccountSetting_tblAccountActivity]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblAccountControl] FOREIGN KEY([AccountControlID])

REFERENCES [dbo].[tblAccountControl] ([AccountControlID])

GO

ALTER TABLE [dbo].[tblAccountSetting] CHECK CONSTRAINT [FK_tblAccountSetting_tblAccountControl]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblAccountHead] FOREIGN KEY([AccountHeadID])

REFERENCES [dbo].[tblAccountHead] ([AccountHeadID])

GO

ALTER TABLE [dbo].[tblAccountSetting] CHECK CONSTRAINT [FK_tblAccountSetting_tblAccountHead]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH NOCHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblAccountSubControl] FOREIGN KEY([AccountSubControlID])

REFERENCES [dbo].[tblAccountSubControl] ([AccountSubControlID])

NOT FOR REPLICATION 

GO

ALTER TABLE [dbo].[tblAccountSetting] NOCHECK CONSTRAINT [FK_tblAccountSetting_tblAccountSubControl]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblAccountSetting] CHECK CONSTRAINT [FK_tblAccountSetting_tblBranch]

GO

ALTER TABLE [dbo].[tblAccountSetting]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSetting_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblAccountSetting] CHECK CONSTRAINT [FK_tblAccountSetting_tblCompany]

GO

ALTER TABLE [dbo].[tblAccountSubControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSubControl_tblAccountControl] FOREIGN KEY([AccountControlID])

REFERENCES [dbo].[tblAccountControl] ([AccountControlID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblAccountSubControl] CHECK CONSTRAINT [FK_tblAccountSubControl_tblAccountControl]

GO

ALTER TABLE [dbo].[tblAccountSubControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSubControl_tblAccountHead] FOREIGN KEY([AccountHeadID])

REFERENCES [dbo].[tblAccountHead] ([AccountHeadID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblAccountSubControl] CHECK CONSTRAINT [FK_tblAccountSubControl_tblAccountHead]

GO

ALTER TABLE [dbo].[tblAccountSubControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSubControl_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblAccountSubControl] CHECK CONSTRAINT [FK_tblAccountSubControl_tblBranch]

GO

ALTER TABLE [dbo].[tblAccountSubControl]  WITH CHECK ADD  CONSTRAINT [FK_tblAccountSubControl_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblAccountSubControl] CHECK CONSTRAINT [FK_tblAccountSubControl_tblUser]

GO

ALTER TABLE [dbo].[tblBranch]  WITH CHECK ADD  CONSTRAINT [FK_tblBranch_tblBranchType] FOREIGN KEY([BranchTypeID])

REFERENCES [dbo].[tblBranchType] ([BranchTypeID])

GO

ALTER TABLE [dbo].[tblBranch] CHECK CONSTRAINT [FK_tblBranch_tblBranchType]

GO

ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblBranch]

GO

ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblCompany]

GO

ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblUser]

GO

ALTER TABLE [dbo].[tblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomer_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCustomer] CHECK CONSTRAINT [FK_tblCustomer_tblBranch]

GO

ALTER TABLE [dbo].[tblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomer_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCustomer] CHECK CONSTRAINT [FK_tblCustomer_tblCompany]

GO

ALTER TABLE [dbo].[tblCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomer_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCustomer] CHECK CONSTRAINT [FK_tblCustomer_tblUser]

GO

ALTER TABLE [dbo].[tblCustomerInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoice_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCustomerInvoice] CHECK CONSTRAINT [FK_tblCustomerInvoice_tblBranch]

GO

ALTER TABLE [dbo].[tblCustomerInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoice_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCustomerInvoice] CHECK CONSTRAINT [FK_tblCustomerInvoice_tblCompany]

GO

ALTER TABLE [dbo].[tblCustomerInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoice_tblCustomer] FOREIGN KEY([CustomerID])

REFERENCES [dbo].[tblCustomer] ([CustomerID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblCustomerInvoice] CHECK CONSTRAINT [FK_tblCustomerInvoice_tblCustomer]

GO

ALTER TABLE [dbo].[tblCustomerInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoice_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCustomerInvoice] CHECK CONSTRAINT [FK_tblCustomerInvoice_tblUser]

GO

ALTER TABLE [dbo].[tblCustomerInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoiceDetail_tblCustomerInvoice] FOREIGN KEY([CustomerInvoiceID])

REFERENCES [dbo].[tblCustomerInvoice] ([CustomerInvoiceID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblCustomerInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerInvoiceDetail_tblCustomerInvoice]

GO

ALTER TABLE [dbo].[tblCustomerInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerInvoiceDetail_tblStock] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblCustomerInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerInvoiceDetail_tblStock]

GO

ALTER TABLE [dbo].[tblCustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerPayment_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCustomerPayment] CHECK CONSTRAINT [FK_tblCustomerPayment_tblBranch]

GO

ALTER TABLE [dbo].[tblCustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerPayment_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCustomerPayment] CHECK CONSTRAINT [FK_tblCustomerPayment_tblCompany]

GO

ALTER TABLE [dbo].[tblCustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerPayment_tblCustomerInvoice] FOREIGN KEY([CustomerInvoiceID])

REFERENCES [dbo].[tblCustomerInvoice] ([CustomerInvoiceID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblCustomerPayment] CHECK CONSTRAINT [FK_tblCustomerPayment_tblCustomerInvoice]

GO

ALTER TABLE [dbo].[tblCustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerPayment_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCustomerPayment] CHECK CONSTRAINT [FK_tblCustomerPayment_tblUser]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoice_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice] CHECK CONSTRAINT [FK_tblCustomerReturnInvoice_tblBranch]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoice_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice] CHECK CONSTRAINT [FK_tblCustomerReturnInvoice_tblCompany]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoice_tblCustomer] FOREIGN KEY([CustomerID])

REFERENCES [dbo].[tblCustomer] ([CustomerID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice] CHECK CONSTRAINT [FK_tblCustomerReturnInvoice_tblCustomer]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoice_tblCustomerInvoice] FOREIGN KEY([CustomerInvoiceID])

REFERENCES [dbo].[tblCustomerInvoice] ([CustomerInvoiceID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice] CHECK CONSTRAINT [FK_tblCustomerReturnInvoice_tblCustomerInvoice]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoice_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoice] CHECK CONSTRAINT [FK_tblCustomerReturnInvoice_tblUser]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerInvoice] FOREIGN KEY([CustomerInvoiceID])

REFERENCES [dbo].[tblCustomerInvoice] ([CustomerInvoiceID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerInvoice]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerInvoiceDetail] FOREIGN KEY([CustomerInvoiceDetailID])

REFERENCES [dbo].[tblCustomerInvoiceDetail] ([CustomerInvoiceDetailID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerInvoiceDetail]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerReturnInvoice] FOREIGN KEY([CustomerReturnInvoiceID])

REFERENCES [dbo].[tblCustomerReturnInvoice] ([CustomerReturnInvoiceID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblCustomerReturnInvoice]

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblStock] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

GO

ALTER TABLE [dbo].[tblCustomerReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblCustomerReturnInvoiceDetail_tblStock]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblBranch]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblCompany]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomer] FOREIGN KEY([CustomerID])

REFERENCES [dbo].[tblCustomer] ([CustomerID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomer]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomerInvoice] FOREIGN KEY([CustomerInvoiceID])

REFERENCES [dbo].[tblCustomerInvoice] ([CustomerInvoiceID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomerInvoice]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomerReturnInvoice] FOREIGN KEY([CustomerReturnInvoiceID])

REFERENCES [dbo].[tblCustomerReturnInvoice] ([CustomerReturnInvoiceID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblCustomerReturnInvoice]

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerReturnPayment_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblCustomerReturnPayment] CHECK CONSTRAINT [FK_tblCustomerReturnPayment_tblUser]

GO

ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblBranch]

GO

ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblCompany]

GO

ALTER TABLE [dbo].[tblFinancialYear]  WITH CHECK ADD  CONSTRAINT [FK_tblFinancialYear_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblFinancialYear] CHECK CONSTRAINT [FK_tblFinancialYear_tblUser]

GO

ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblBranch]

GO

ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblCompany]

GO

ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblEmployee] FOREIGN KEY([EmployeeID])

REFERENCES [dbo].[tblEmployee] ([EmployeeID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblEmployee]

GO

ALTER TABLE [dbo].[tblPayroll]  WITH CHECK ADD  CONSTRAINT [FK_tblPayroll_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblPayroll] CHECK CONSTRAINT [FK_tblPayroll_tblUser]

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseCartDetail_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail] CHECK CONSTRAINT [FK_tblPurchaseCartDetail_tblBranch]

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseCartDetail_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail] CHECK CONSTRAINT [FK_tblPurchaseCartDetail_tblCompany]

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseCartDetail_tblStock] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail] CHECK CONSTRAINT [FK_tblPurchaseCartDetail_tblStock]

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseCartDetail_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblPurchaseCartDetail] CHECK CONSTRAINT [FK_tblPurchaseCartDetail_tblUser]

GO

ALTER TABLE [dbo].[tblSaleCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSaleCartDetail_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblSaleCartDetail] CHECK CONSTRAINT [FK_tblSaleCartDetail_tblCompany]

GO

ALTER TABLE [dbo].[tblSaleCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSaleCartDetail_tblStock] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblSaleCartDetail] CHECK CONSTRAINT [FK_tblSaleCartDetail_tblStock]

GO

ALTER TABLE [dbo].[tblSaleCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSaleCartDetail_tblStock1] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

GO

ALTER TABLE [dbo].[tblSaleCartDetail] CHECK CONSTRAINT [FK_tblSaleCartDetail_tblStock1]

GO

ALTER TABLE [dbo].[tblSaleCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSaleCartDetail_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSaleCartDetail] CHECK CONSTRAINT [FK_tblSaleCartDetail_tblUser]

GO

ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblBranch]

GO

ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblCategory] FOREIGN KEY([CategoryID])

REFERENCES [dbo].[tblCategory] ([CategoryID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblCategory]

GO

ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblCompany]

GO

ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblUser]

GO

ALTER TABLE [dbo].[tblSupplier]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplier_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblSupplier] CHECK CONSTRAINT [FK_tblSupplier_tblBranch]

GO

ALTER TABLE [dbo].[tblSupplier]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplier_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblSupplier] CHECK CONSTRAINT [FK_tblSupplier_tblCompany]

GO

ALTER TABLE [dbo].[tblSupplier]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplier_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSupplier] CHECK CONSTRAINT [FK_tblSupplier_tblUser]

GO

ALTER TABLE [dbo].[tblSupplierInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoice_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSupplierInvoice] CHECK CONSTRAINT [FK_tblSupplierInvoice_tblUser]

GO

ALTER TABLE [dbo].[tblSupplierInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoiceTable_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblSupplierInvoice] CHECK CONSTRAINT [FK_tblSupplierInvoiceTable_tblBranch]

GO

ALTER TABLE [dbo].[tblSupplierInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoiceTable_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblSupplierInvoice] CHECK CONSTRAINT [FK_tblSupplierInvoiceTable_tblCompany]

GO

ALTER TABLE [dbo].[tblSupplierInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoiceTable_tblSupplier] FOREIGN KEY([SupplierID])

REFERENCES [dbo].[tblSupplier] ([SupplierID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblSupplierInvoice] CHECK CONSTRAINT [FK_tblSupplierInvoiceTable_tblSupplier]

GO

ALTER TABLE [dbo].[tblSupplierInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoiceDetail_tblStock] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblSupplierInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierInvoiceDetail_tblStock]

GO

ALTER TABLE [dbo].[tblSupplierInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierInvoiceDetail_tblSupplierInvoice] FOREIGN KEY([SupplierInvoiceID])

REFERENCES [dbo].[tblSupplierInvoice] ([SupplierInvoiceID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblSupplierInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierInvoiceDetail_tblSupplierInvoice]

GO

ALTER TABLE [dbo].[tblSupplierPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierPayment_tblSupplier] FOREIGN KEY([SupplierID])

REFERENCES [dbo].[tblSupplier] ([SupplierID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblSupplierPayment] CHECK CONSTRAINT [FK_tblSupplierPayment_tblSupplier]

GO

ALTER TABLE [dbo].[tblSupplierPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierPayment_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSupplierPayment] CHECK CONSTRAINT [FK_tblSupplierPayment_tblUser]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoice_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice] CHECK CONSTRAINT [FK_tblSupplierReturnInvoice_tblBranch]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoice_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice] CHECK CONSTRAINT [FK_tblSupplierReturnInvoice_tblCompany]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoice_tblSupplier] FOREIGN KEY([SupplierID])

REFERENCES [dbo].[tblSupplier] ([SupplierID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice] CHECK CONSTRAINT [FK_tblSupplierReturnInvoice_tblSupplier]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoice_tblSupplierInvoice] FOREIGN KEY([SupplierInvoiceID])

REFERENCES [dbo].[tblSupplierInvoice] ([SupplierInvoiceID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice] CHECK CONSTRAINT [FK_tblSupplierReturnInvoice_tblSupplierInvoice]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoice_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoice] CHECK CONSTRAINT [FK_tblSupplierReturnInvoice_tblUser]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblStock] FOREIGN KEY([ProductID])

REFERENCES [dbo].[tblStock] ([ProductID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblStock]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierInvoice] FOREIGN KEY([SupplierInvoiceID])

REFERENCES [dbo].[tblSupplierInvoice] ([SupplierInvoiceID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierInvoice]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierInvoiceDetail] FOREIGN KEY([SupplierInvoiceDetailID])

REFERENCES [dbo].[tblSupplierInvoiceDetail] ([SupplierInvoiceDetailID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierInvoiceDetail]

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierReturnInvoice] FOREIGN KEY([SupplierReturnInvoiceID])

REFERENCES [dbo].[tblSupplierReturnInvoice] ([SupplierReturnInvoiceID])

GO

ALTER TABLE [dbo].[tblSupplierReturnInvoiceDetail] CHECK CONSTRAINT [FK_tblSupplierReturnInvoiceDetail_tblSupplierReturnInvoice]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblBranch] FOREIGN KEY([BranchID])

REFERENCES [dbo].[tblBranch] ([BranchID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblBranch]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblCompany] FOREIGN KEY([CompanyID])

REFERENCES [dbo].[tblCompany] ([CompanyID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblCompany]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplier] FOREIGN KEY([SupplierID])

REFERENCES [dbo].[tblSupplier] ([SupplierID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplier]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplierInvoice] FOREIGN KEY([SupplierInvoiceID])

REFERENCES [dbo].[tblSupplierInvoice] ([SupplierInvoiceID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplierInvoice]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplierReturnInvoice] FOREIGN KEY([SupplierReturnInvoiceID])

REFERENCES [dbo].[tblSupplierReturnInvoice] ([SupplierReturnInvoiceID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblSupplierReturnInvoice]

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierReturnPayment_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblSupplierReturnPayment] CHECK CONSTRAINT [FK_tblSupplierReturnPayment_tblUser]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblAccountControl] FOREIGN KEY([AccountControlID])

REFERENCES [dbo].[tblAccountControl] ([AccountControlID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblAccountControl]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblAccountHead] FOREIGN KEY([AccountHeadID])

REFERENCES [dbo].[tblAccountHead] ([AccountHeadID])

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblAccountHead]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblFinancialYear] FOREIGN KEY([FinancialYearID])

REFERENCES [dbo].[tblFinancialYear] ([FinancialYearID])

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblFinancialYear]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransaction_tblUser] FOREIGN KEY([UserID])

REFERENCES [dbo].[tblUser] ([UserID])

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransaction_tblUser]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransection_tblAccountHead] FOREIGN KEY([AccountHeadID])

REFERENCES [dbo].[tblAccountHead] ([AccountHeadID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransection_tblAccountHead]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransection_tblAccountSubControl] FOREIGN KEY([AccountSubControlID])

REFERENCES [dbo].[tblAccountSubControl] ([AccountSubControlID])

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransection_tblAccountSubControl]

GO

ALTER TABLE [dbo].[tblTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tblTransection_tblFinancialYear] FOREIGN KEY([FinancialYearID])

REFERENCES [dbo].[tblFinancialYear] ([FinancialYearID])

ON UPDATE CASCADE

ON DELETE CASCADE

GO

ALTER TABLE [dbo].[tblTransaction] CHECK CONSTRAINT [FK_tblTransection_tblFinancialYear]

GO

ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblUserType] FOREIGN KEY([UserTypeID])

REFERENCES [dbo].[tblUserType] ([UserTypeID])

GO

ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblUserType]