using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Shared
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.Property(b => b.Name).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Email).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Business).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Unit).IsRequired().HasMaxLength(500);
            builder.Property(b => b.CreatedBy).HasMaxLength(500);
            builder.Property(b => b.ModifiedBy).HasMaxLength(500);
            builder.HasKey(b => b.Id);

            //unique constraint
            builder.HasIndex(b => b.Email)
            .IsUnique();

            builder.HasData(
            #region User
             //Risk
             User.Create("Chukwuebuka Obieri", "chukwuebuka.obieri@arm.com.ng", "Shared Services", "Risk Management", new Guid(SharedServicesRiskManagement.RiskManagement)),
             User.Create("Iwasam Elemi", "iwasam.elemi@arm.com.ng", "Shared Services", "Risk Management", new Guid(SharedServicesRiskManagement.RiskManagement)),
             User.Create("Thelma.Uwandu", "thelma.uwandu@arm.com.ng", "Shared Services", "Risk Management", new Guid(SharedServicesRiskManagement.RiskManagement)),
             User.Create("Nehizena Ibhawoh", "nehizena.ibhawoh@arm.com.ng", "Shared Services", "Legal,Compliance", new Guid(SharedServicesLegalCompliance.Legal)),
             User.Create("Olabisi Adesina", "olabisi.adesina@arm.com.ng", "Shared Services", "Legal", new Guid(SharedServicesLegalCompliance.Legal)),
            User.Create("Ediagbonya Osayomwanbo", "ediagbonya.osayomwanbo@arm.com.ng", "ARM IM", "WRM (Abuja)", new Guid(ARMIMBusinessSupport.Abuja)),
            User.Create("James Ewah", "james.ewah@arm.com.ng", "ARM IM", "WRM (Abuja)", new Guid(ARMIMBusinessSupport.Abuja)),
            User.Create("Olayemi Toye", "olayemi.toye@arm.com.ng", "Shared Services", "Information Technology", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
            User.Create("Phoebe Ohiembor", "phoebe.ohiembor@arm.com.ng", "Shared Services", "Information Technology", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
            User.Create("Ethan Okwara", "ethan.okwara@arm.com.ng", "Shared Services", "Marketing and Corporate Communications", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
            User.Create("Ubi Torsam", "ubi.torsam@arm.com.ng", "Shared Services", "Marketing and Corporate Communications", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
            User.Create("Stephen Igwenwanne", "stephen.igwenwanne@arm.com.ng", "ARM IM", "WRM (PortHarcourt)", new Guid(ARMIMBusinessSupport.PortHarcourt)),
            User.Create("Ndubuisi Anya", "ndubuisi.anya@arm.com.ng", "ARM IM", "WRM (PortHarcourt)", new Guid(ARMIMBusinessSupport.PortHarcourt)),
            User.Create("Hassan AdeObafemi", "hassan.adeObafemi@arm.com.ng", "ARM Agricbusiness Fund Manager Ltd", "RFL", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
            User.Create("David Akinboade", "david.akinboade@arm.com.ng", "ARM Agricbusiness Fund Manager Ltd", "RFL", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
            User.Create("Eddy Ayikimi", "eddy.ayikimi@arm.com.ng", "Shared Services", "Customer Experience", new Guid(SharedServicesCustomerExperience.CustomerService)),
            User.Create("Akpesiri Kodu", "akpesiri.kodu@arm.com.ng", "Shared Services", "Customer Experience", new Guid(SharedServicesCustomerExperience.CustomerService)),
            User.Create("Adeleye Adewusi", "adeleye.adewusi@arm.com.ng", "Shared Services", "ARM Academy", new Guid(SharedServicesARMAcademy.ARMAcademy)),
            User.Create("Olatunde Samuel", "olatunde.samuel@arm.com.ng", "Shared Services", "ARM Academy", new Guid(SharedServicesARMAcademy.ARMAcademy)),
            User.Create("Bimbo Moses", "bimbo.moses@arm.com.ng", "ARM IM", "Retail Operations", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
            User.Create("Aminat Ashafa", "aminat.ashafa@arm.com.ng", "ARM IM", "Retail Operations", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
            User.Create("Oluwaferanmi Olorunleke", "oluwaferanmi.olorunleke@arm.com.ng", "ARM Trustees", "ARM Private Trust", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
            User.Create("Folarinde Ayenuwa", "folarinde.ayenuwa@arm.com.ng", "ARM Trustees", "ARM Private Trust", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
            User.Create("Ibukun Ajose", "ibukun.ajose@arm.com.ng", "Shared Services", "Treasury", new Guid(SharedServicesFinanceTreasury.Treasury)),
            User.Create("Kevian Kevin", "kevian.kevin@arm.com.ng", "Shared Services", "Treasury", new Guid(SharedServicesFinanceTreasury.Treasury)),
            User.Create("Raymond Akorah", "raymond.akorah@arm.com.ng", "ARM IM", "ARM Registrars", new Guid(ARMIMBackOfficeOperations.Registrars)),
            User.Create("Ina Alogwu", "ina.alogwu@arm.com.ng", "ARM Digital Financial Services", "Digital Financial Services", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
            User.Create("Folaranmi Adefila", "folaranmi.adefila@arm.com.ng", "ARM Digital Financial Services", "Digital Financial Services", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
            User.Create("Oritsegbemi Agbajor", "oritsegbemi.agbajor@arm.com.ng", "ARM Trustees", "ARM Commercial Trust", new Guid(ARMTrusteesCommercialTrust.CommercialTrust)),
            User.Create("Chidinma Mbakwe", "chidinma.mbakwe@arm.com.ng", "ARM Trustees", "ARM Commercial Trust", new Guid(ARMTrusteesCommercialTrust.CommercialTrust)),
            User.Create("Olugbenga Ajigbotafe", "olugbenga.ajigbotafe@arm.com.ng", "Shared Services", "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
            User.Create("Joy Oyekan", "joy.oyekan@arm.com.ng", "Shared Services", "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
            User.Create("Oluwabunmi Abiodun-Wright", "oluwabunmi.abiodun-wright@arm.com.ng", "Shared Services", "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Ezekiel Solomon", "ezekiel.solomon@arm.com.ng", "Shared Services", "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Judith Okeke", "judith.okeke@arm.com.ng", "ARM Securities", "Trading & Brokerage", new Guid(ARMSecuritiesTradingBokerage.TradingBokerage)),
            User.Create("Carol Ariyibi", "carol.ariyibi@arm.com.ng", "Shared Services", "Corporate Transformation", new Guid(SharedServicesCoporateTransformationUnit.CoporateTransformation)),
            User.Create("Olaoluwa Omolayole", "olaoluwa.omolayole@arm.com.ng", "Shared Services", "Corporate Transformation", new Guid(SharedServicesCoporateTransformationUnit.CoporateTransformation)),
            User.Create("Jacqueline Adefeso", "jacqueline.adefeso@arm.com.ng", "Shared Services", "Procurement and Administration", new Guid(SharedServicesProcurementandAdministration.ProcurementandAdministration)),
            User.Create("Moradeke Odugbesan", "moradeke.odugbesan@arm.com.ng", "Shared Services", "Procurement and Administration", new Guid(SharedServicesProcurementandAdministration.ProcurementandAdministration)),
            User.Create("Dare Shobajo", "dare.shobajo@arm.com.ng", "Shared Services", "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
            User.Create("Moshood Hassan", "moshood.hassan@arm.com.ng", "Shared Services", "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
            User.Create("Vwede Edah", "vwede.edah@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
            User.Create("Opeyemi Babasola", "opeyemi.babasola@arm.com.ng", "ARM Securities", "Securities Operations,Financial Control", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
            User.Create("Doyinsola Ola", "doyinsola.ola@arm.com.ng", "ARM IM", "WRM (Lagos)", new Guid(ARMIMBusinessSupport.Lagos)),
            User.Create("Rasheed Adebola", "rasheed.adebola@arm.com.ng", "ARM IM", "WRM (Lagos)", new Guid(ARMIMBusinessSupport.Lagos)),
            User.Create("Gozie Alozieuwa", "gozie.alozieuwa@arm.com.ng", "Shared Services", "Compliance", new Guid(SharedServicesLegalCompliance.Compliance)),
            User.Create("Lincoln Ogigai", "lincoln.ogigai@arm.com.ng", "Shared Services", "Compliance", new Guid(SharedServicesLegalCompliance.Compliance)),
            User.Create("Oyinkan Aregbesola", "oyinkan.aregbesola@arm.com.ng", "ARM Securities", "Research", new Guid(ARMSecuritiesResearch.Research)),
            User.Create("Moyosore Taiwo", "moyosore.taiwo@arm.com.ng", "ARM Securities", "Research", new Guid(ARMSecuritiesResearch.Research)),
            User.Create("Jobalo Oshinkalu", "jobalo.oshinkalu@arm.com.ng", "ARM Harith Infracstrure Investement Limited", "ARM Harith Infrastructure Investment Ltd", new Guid(ARMHarithInfracstrureInvestementLimitedARMHarithInfrastructureInvestmentLtd.ARMHarithInfrastructureInvestmentLtd)),
            User.Create("Oyedele Oyinbojuni", "oyedele.oyinbojuni@armharith.com", "ARM Harith Infracstrure Investement Limited", "ARM Harith Infrastructure Investment Ltd", new Guid(ARMHarithInfracstrureInvestementLimitedARMHarithInfrastructureInvestmentLtd.ARMHarithInfrastructureInvestmentLtd)),
            User.Create("Isaac Elakhe", "isaac.elakhe@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Oladupe Oshinuga", "oladupe.oshinuga@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Adetayo Adebiyi", "adetayo.adebiyi@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Oluwatobi Oyebiyi", "oluwatobi.oyebiyi@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Itunu Olatunde-Folaji", "itunu.olatunde-folaji@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Roselina Ajah", "roselina.ajah@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Abayomi Apoeso", "abayomi.apoeso@arm.com.ng", "Shared Services", "Information Security", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
            User.Create("Faith Sani", "faith.sani@arm.com.ng", "Shared Services", "Information Security", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
            User.Create("Mounir Bouba", "mounir.bouba@arm.com.ng", "ARM IM", "Investment Managment", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Chukwufumnanya Chizea", "chukwufumnanya.chizea@arm.com.ng", "ARM IM", "Investment Managment", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Raphael Emenyonu", "raphael.emenyonu@arm.com.ng", "ARM IM", "Retail Sales", new Guid(ARMIMRetailSales.Lagos)),
            User.Create("Hamed Omotayo", "hamed.omotayo@arm.com.ng", "ARM IM", "Retail Sales", new Guid(ARMIMRetailSales.Lagos)),
            User.Create("Anuoluwapo Sebanjo", "anuoluwapo.sebanjo@arm.com.ng", "Shared Services", "Corporate Strategy", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
            User.Create("Philip Aikinomiora", "philip.aikinomiora @arm.com.ng", "Shared Services", "Corporate Strategy", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
            User.Create("Gbeminiyi Onipede", "gbeminiyi.onipede@arm.com.ng", "ARM HoldCo", "HoldCo Sales", new Guid(ARMHoldCoHoldCoSales.HoldCoSales)),
            User.Create("Olukayode Fajuyagbe", "olukayode.fajuyagbe@arm.com.ng", "ARM HoldCo", "HoldCo Sales", new Guid(ARMHoldCoHoldCoSales.HoldCoSales)),
            User.Create("Opeyemi Oshinyemi", "opeyemi.oshinyemi@arm.com.ng", "ARM IM", "Operations Control", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("James Agu", "james.agu@arm.com.ng", "ARM IM", "Operations Control", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Olawale Bakir", "olawale.bakir@arm.com.ng", "Shared Services", "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
            User.Create("Barakat Olusanya", "barakat.olusanya@arm.com.ng", "Shared Services", "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)), //Done

            //Compliance control
            User.Create("Gbenga Sonubi", "gbenga.sonubi@arm.com.ng", "ARM Securities", "Securities Operations,Financial Control", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
            User.Create("Kareem Bashir", "kareem.bashir@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Patrick Ayele", "patrick.ayele@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Oluyemi Omodayo", "oluyemi.omodayo@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Oluwatosin Adeboyejo", "oluwatosin.adeboyejo@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Elizabeth Alloy", "elizabeth.alloy@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Stephanie Gber", "stephanie.gber@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Temitope Akinola", "temitope.akinola@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Valerie Okosun", "valerie.okosun@arm.com.ng", "ARM IM", "Securities Operations,Financial Control", new Guid(ARMIMFinanceTreasury.FinancialControl)),
            User.Create("Kingsley Ottah", "kingsley.ottah@arm.com.ng", "ARM IM", "Financial Control", new Guid(ARMIMFinanceTreasury.FinancialControl)),
            User.Create("Ramond Akorah", "ramond.akorah@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
            User.Create("Oluwatosin Afolayan", "oluwatosin.afolayan@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
            User.Create("Evelyn Nwogu", "evelyn.nwogu@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Babatunde Osho", "babatunde.osho@arm.com.ng", "ARM Securities", "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
            User.Create("Augustine Chukwu", "augustine.chukwu@arm.com.ng", "ARM Securities", "Information Security", new Guid(SharedServicesInformationSecurity.InformationSecurity)),
            User.Create("Kiadum Nwakoh", "kiadum.nwakoh@arm.com.ng", "ARM Securities", "Legal,Compliance", new Guid(SharedServicesLegalCompliance.Legal)),
            User.Create("Emmanuella Anaza", "emmanuella.anaza@arm.com.ng", "ARM TRUSTEES", "Financial Control", new Guid(ARMTrusteesFinanceTreasury.FinancialControl)),
            User.Create("Sandra Onwordi", "sandra.onwordi@arm.com.ng", "ARM IM", "Financial Control", new Guid(ARMIMFinanceTreasury.FinancialControl)),
            User.Create("Oluwatomilola Oduntan", "oluwatomilola.oduntan@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Ogugua Emamoke", "ogugua.emamoke@arm.com.ng", "Shared Services", "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)), 
            User.Create("Abiola Itakpe", "abiola.itakpe@arm.com.ng", "Shared Services", "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
            User.Create("Chidinma Akosa", "chidinma.akosa@arm.com.ng", "Shared Services", "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)), 
            User.Create("Ifeoma Ofili", "ifeoma.ofili@arm.com.ng", "ARM Securities", "Treasury", new Guid(ARMSecuritiesFinanceTreasury.Treasury)),
            User.Create("Ademola Adebisi", "ademola.adebisi@arm.com.ng", "ARM Securities", "Treasury", new Guid(ARMSecuritiesFinanceTreasury.Treasury)),
            User.Create("Victoria Itrechio", "victoria.itrechio@arm.com.ng", "ARM Securities", "Treasury", new Guid(ARMSecuritiesFinanceTreasury.Treasury)), //Done

            //Audit
            User.Create("Adebayo Fagbola", "adebayo.fagbola@arm.com.ng", "ARM SharedService", "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Maryann Kakulu", "maryann.kakulu@arm.com.ng", "ARM SharedService", "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Babatunde Abimbola", "babatunde.abimbola@arm.com.ng", "ARM SharedService", "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Kai Orga", "kai.orga@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Moronke Bamgbala", "moronke.bamgbala@arm.com.ng", "ARM SharedService", "ARM Trustees", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Uche Azubuike", "uche.azubuike@arm.com.ng", "ARM SharedService", "RFL", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Wilfird Korsaga", "Wilfird.korsaga@arm.com.ng", "ARM SharedService", "AAFML", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Yusuf Agbolahan", "yusuf.agbolahan@arm.com.ng", "ARM SharedService", "Investment Banking", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Rachel Moreoshodi", "rachel.moreoshodi@arm.com.ng", "ARM SharedService", "ARMHIIL", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Damilare Mmesimo", "damilare.mesimo@arm.com.ng", "ARM SharedService", "DFS", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Funmilayo Adeyemi", "funmilayo.adeyemi@arm.com.ng", "ARM SharedService", "DFS", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Jobalo Oshikanlu", "jobalo.oshikanlu@arm.com.ng", "ARM SharedService", "ARMHIIL", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Toni Timi-Oyefolu", "toni.timi-oyefolu@arm.com.ng", "ARM SharedService", "ARMIM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Jumoke Ogundare", "jumoke.ogundare@arm.com.ng", "ARM SharedService", "ARM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Wale Odutola", "wale.odutola@arm.com.ng", "ARM SharedService", "ARM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Osahon Ogiemudia", "osahon.ogiemudia@arm.com.ng", "ARM SharedService", "ARM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),  //Done

            //auditee
            User.Create("Chijioke Iteghete", "chijioke.iteghete@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Ayodele Oluleye", "ayodele.oluleye@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Adepeju Sangotade", "adepeju.sangotade@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Anuoluwapo Senbanjo", "anuoluwapo.senbanjo@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Walter Agbongbohielu", "walter.agbongbohielu@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Olufisayo Bassey", "olufisayo.bassey@arm.com.ng", "ARM IM", "Investment Management", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Opeyemi Oshiyemi", "opeyemi.oshiyemi@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Tobi Babalola", "tobi.babalola@arm.com.ng", "ARM SharedService", "ARM IM", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
            User.Create("Oluwatosin Oluyemi", "oluwatosin.oluyemi@arm.com.ng", "ARM Trustees", "ARM Private Trust", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)), //Done

            //Internal Control
            User.Create("Tosin Adesope", "tosin.adesope@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Tobby Moses Tobby", "tobby.tobby@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Olayinka Oyewole", "olayinka.oyewole@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Ifeanyi Esogwa", "ifeanyi.esogwa@arm.com.ng", "Shared Services", "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            User.Create("Victor Arowolo", "victor.arowolo@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMOperationsSettlement.OperationsSettlements)),
            User.Create("Oluwaferanmi Adedokun", "oluwaferanmi.adedokun@arm.com.ng", "ARM IM", "Retail Operations", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
            User.Create("Oyenike Oluwa", "oyenike.oluwa@arm.com.ng", "ARM IM", "Retail Operations", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
            User.Create("Rosemary Francis", "rosemary.francis@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Busola Alakija", "busola.alakija@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Augustina Osagie", "augustina.osagie@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMOperationsSettlement.OperationsSettlements)),
            User.Create("Emmanuel Peter", "emmanuel.peter@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMOperationsSettlement.OperationsSettlements)),
            User.Create("Toluwalase Ajediti", "toluwalase.ajediti@arm.com.ng", "ARM IM", "Operations Settlement", new Guid(ARMIMOperationsSettlement.OperationsSettlements)),
            User.Create("Oluseyi Omoleye", "oluseyi.omoleye@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Thompson Shedara", "thompson.shedara@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Oladupe Dare", "oladupe.dare@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Martins Onemolease", "martins.onemolease@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Ifeoluwani Okunoye", "ifeoluwani.okunoye@arm.com.ng", "ARM IM", "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
            User.Create("Hassan Balogun", "hassan.balogun@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Chioma Opara", "chioma.opara@arm.com.ng", "ARM IM", "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
            User.Create("Ibrahim Owolabi", "ibrahim.owolabi@arm.com.ng", "ARM HoldCo", "Treasury", new Guid(ARMHoldCoFinanceTreasury.Treasury)),
            User.Create("Oluwakemi Onipede", "oluwakemi.onipede@arm.com.ng", "ARM HoldCo", "Treasury", new Guid(ARMHoldCoFinanceTreasury.Treasury)),
            User.Create("Covenant Ukachi", "covenant.ukachi@arm.com.ng", "ARM IM", "Registrars", new Guid(ARMIMBackOfficeOperations.Registrars)),
            User.Create("Bukunmi Chuka", "bukunmi.chuka@arm.com.ng", "ARM HoldCo", "Registrars", new Guid(ARMHoldCoBackOfficeOperations.Register)),
            User.Create("Bridget Odubela", "bridget.odubela@arm.com.ng", "ARM IM", "Registrars", new Guid(ARMIMBackOfficeOperations.Registrars)),
            User.Create("Amara Nwafor", "amara.nwafor@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Chisom Okeke", "chisom.okeke@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Ifeyinwa Amadi", "ifeyinwa.amadi@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Victoria Makama", "victoria.makama@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Dolapo Fashina", "dolapo.fashina@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Oluwabunmi Ayeni", "oluwabunmi.ayeni@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Eno Udoh", "eno.udoh@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Busola Akerele", "busola.akerele@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Inemesit Anani", "inemesit.anani@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Adedolapo Oyeleke", "dolapo.oyeleke@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Chinonso Okocha", "chinonso.okocha@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Simisola Famous-Cole", "simisola.famous-cole@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Rukayat Adepitan", "rukayat.adepitan@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Deborah Dubukumah", "deborah.dubukumah@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Damilola Akinlade", "damilola.akinlade@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Yetunde Adio", "yetunde.adio@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Shulammite Wokwereze", "shulammite.wokwereze@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Bukola Abdulakeem", "bukola.abdulakeem@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Lebechi Ndukwe", "lebechi.ndukwe@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Esther Onumaegbu", "esther.onumaegbu@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Godwin Ebie", "godwin.ebie@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Faith Ojo", "faith.ojo@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Veronica Oluigbo", "veronica.oluigbo@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Anike Olalere", "anike.olalere@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Chukwuebuka Agbo", "chukwuebuka.agbo@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Chinonso Iwuozor", "chinonso.iwuozor@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Jane David-Abia", "jane.david-abia@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Olufunke Sipe", "olufunke.sipe@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Moyosore Ibitoye", "moyosore.ibitoye@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Victoria Chukwu", "victoria.chukwu@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Evelyn Osindeinde", "evelyn.osindeinde@arm.com.ng", "ARM Securities", "Customer Experience", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
            User.Create("Adaeze Ukah", "adaeze.ukah@arm.com.ng", "ARM Securities", "Customer Experience", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
            User.Create("Taiwo Odumuyiwa", "taiwo.odumuyiwa@arm.com.ng", "ARM Securities", "Customer Experience", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
            User.Create("Adepeju-Lola Sangotade", "adepeju-lola.sangotade@arm.com.ng", "ARM IM", "Customer Experience", new Guid(ARMIMCustomerExperience.CustomerService)),
            User.Create("Enoma Osazee", "enoma.osazee@arm.com.ng", "ARM Shared Services", "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
            User.Create("Amaka Nnotum", "amaka.nnotum@arm.com.ng", "ARM HoldCo", "Financial Control", new Guid(ARMHoldCoFinanceTreasury.FinancialControl)),
            User.Create("Ayomide Ojeniyi", "ayomide.ojeniyi@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesARMSecurity.ARMSecurities)),
            User.Create("Lawrence Olusina", "lawrence.olusina@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesARMSecurity.ARMSecurities)),
            User.Create("Ilerioluwa Akinosun", "ilerioluwa.akinosun@arm.com.ng", "ARM Securities", "Securities Operations", new Guid(ARMSecuritiesARMSecurity.ARMSecurities)),
            User.Create("Olashile Abowaba", "olashile.abowaba@arm.com.ng", "ARM IM", "Investment Management", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Ifeoluwa Obigbemi", "ifeoluwa.obigbemi@arm.com.ng", "ARM IM", "Investment Management", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Gift Aizebeoje", "gift.aizebeoje@arm.com.ng", "ARM IM", "Investment Management", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
            User.Create("Adeolu Folayira", "adeolu.folayira@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),

            //Operation Control
            User.Create("Hannah Aliu", "hannah.aliu@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Oluwafunke Nasiru", "oluwafunke.nasiru@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Ademola Fatade", "ademola.fatade@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Faizat Adeboye", "faizat.adeboye@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Taiwo Olusola", "taiwo.olusola@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Olanrewaju Fatai@", "olanrewaju.fatai@arm.com.ng", "ARM IM", "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            User.Create("Joy Ogunbi", "joy.ogunbi@arm.com.ng", "Shared Services", "Information Security", new Guid(SharedServicesInformationTechnology.InformationTechnology))

            #endregion

             );
        }
    }
}
