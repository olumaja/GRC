using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceDepartmentConfiguration : IEntityTypeConfiguration<ComplianceDepartment>
    {
        public void Configure(EntityTypeBuilder<ComplianceDepartment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                ComplianceDepartment.Create(Guid.Parse("9443293C-A893-41DE-8317-264444C8BBC2"), "Abuja"),
                ComplianceDepartment.Create(Guid.Parse("4C9B0A56-52DC-4B33-AF2B-5C999308A0AE"), "Adiva"),
                ComplianceDepartment.Create(Guid.Parse("4F52F84C-20CF-459E-8C9C-48D7072F30C5"), "Administration"),
                ComplianceDepartment.Create(Guid.Parse("DA0BCBE0-9DAD-4F4A-822F-3C0F9005CAE8"), "Advisory"),
                ComplianceDepartment.Create(Guid.Parse("8F9DFE1B-0CA1-4722-B2A1-09609EE3BB0A"), "ARM Academy"),
                ComplianceDepartment.Create(Guid.Parse("2F10B305-B9DA-4801-9188-133C042B276A"), "ARM Agric Fund"),
                ComplianceDepartment.Create(Guid.Parse("D969CBF1-7F32-40BF-9E68-74F71A2D23D6"), "ARM Financial Advisers"),
                ComplianceDepartment.Create(Guid.Parse("EBDE322F-5DF1-4AF1-AEB8-870DF4C58B3C"), "ARM Harith Infrastructure Investment Ltd"),
                ComplianceDepartment.Create(Guid.Parse("9686C1AA-690E-4EFB-A6F0-E48C838EC238"), "ARM Harith Investment Ltd"),
                ComplianceDepartment.Create(Guid.Parse("766DFECD-8DB0-4CC4-981E-43AE1F9F9265"), "Beechwood"),
                ComplianceDepartment.Create(Guid.Parse("C08F04F7-5E1C-42F9-8247-CB902CD62F49"), "Business Planning"),
                ComplianceDepartment.Create(Guid.Parse("469E97DB-72AF-49ED-84DD-C11D425263CB"), "Call Centre"),
                ComplianceDepartment.Create(Guid.Parse("A8E77619-5129-4A88-B234-386F64840215"), "Co.Sec"),
                ComplianceDepartment.Create(Guid.Parse("30C73A8B-1B74-4732-802D-E97B7EA2A404"), "Commercial Trust"),
                ComplianceDepartment.Create(Guid.Parse("037B9FF2-504E-404F-B329-8DFFCC2C5E94"), "Compliance"),
                ComplianceDepartment.Create(Guid.Parse("113DA9BE-B174-48A0-98CF-7573F8F344F7"), "Coporate Transformation"),
                ComplianceDepartment.Create(Guid.Parse("DC1AB4AE-DB59-420B-AADE-49C9C0225B21"), "Corporate Strategy"),
                ComplianceDepartment.Create(Guid.Parse("86B47B0A-C3E1-45B6-97EF-5DEAD8955745"), "Crosstown Iju"),
                ComplianceDepartment.Create(Guid.Parse("4108D577-9409-498B-9822-BBDD9F9B1E6C"), "Customer Service"),
                ComplianceDepartment.Create(Guid.Parse("581ED77E-2E05-42FD-8B92-D001A96909A5"), "Design"),
                ComplianceDepartment.Create(Guid.Parse("732911EA-38E8-4104-A9C9-8101C7EC2748"), "Digital Financial Services"),
                ComplianceDepartment.Create(Guid.Parse("7CC52D32-76D1-4537-B418-7418D09F28F9"), "Enclave"),
                ComplianceDepartment.Create(Guid.Parse("0B760D1E-9EB3-4758-93D8-BEADE293F5D8"), "Facility Management"),
                ComplianceDepartment.Create(Guid.Parse("48CC7B70-9EFA-4125-B448-6A957D2041F5"), "Farapark"),
                ComplianceDepartment.Create(Guid.Parse("51C62493-240A-4122-8AC8-EE1FE16E3EE2"), "Financial Control"),
                ComplianceDepartment.Create(Guid.Parse("8ACEBF76-21E6-4E74-9F8C-B0D1DB9F3753"), "Fund Account"),
                ComplianceDepartment.Create(Guid.Parse("AA8EFD00-7CC1-4FA6-B9E0-B24E06E8A0A5"), "Fund Admin"),
                ComplianceDepartment.Create(Guid.Parse("F2B1A942-B22C-4C66-9929-513BA1867053"), "Greater Port Harcour Golf Club"),
                ComplianceDepartment.Create(Guid.Parse("FAD581C6-2F33-46DE-B1C4-25D3873F23F1"), "HoldCo Sales"),
                ComplianceDepartment.Create(Guid.Parse("A50412B5-65FF-4002-8DA4-A45C5BF4BF2A"), "Hospitality and Retail Management"),
                ComplianceDepartment.Create(Guid.Parse("3D7857E6-8875-477F-A962-247326E2C92D"), "Human Capital Management"),
                ComplianceDepartment.Create(Guid.Parse("DFC65214-67C8-47EB-AEEB-3146AE489E60"), "Information Security"),
                ComplianceDepartment.Create(Guid.Parse("EEFA7C57-98B1-44F8-ABA7-549399321114"), "Information Technology"),
                ComplianceDepartment.Create(Guid.Parse("4FAE7DA7-6DDD-48D0-9400-1126815FB4D5"), "Institutional"),
                ComplianceDepartment.Create(Guid.Parse("1E534470-A920-457D-B5D3-CA8882DE81FF"), "Internal Audit"),
                ComplianceDepartment.Create(Guid.Parse("1C2370DB-3244-4BF2-9B56-57D98BB3B5E7"), "Internal Control"),
                ComplianceDepartment.Create(Guid.Parse("1B5CBD9D-3A11-4AE2-8350-F208D37BCBB5"), "Investment Management"),
                ComplianceDepartment.Create(Guid.Parse("413C704D-AF7B-4B17-BD98-9EEA7B16FF03"), "Lagos"),
                ComplianceDepartment.Create(Guid.Parse("9E94023E-CE76-490C-8F1F-E46F4117B1A3"), "Lakowe Lakes Golf Club Ltd"),
                ComplianceDepartment.Create(Guid.Parse("6D071E04-9A34-4C6B-AAA0-EF9F11470990"), "Legal"),
                ComplianceDepartment.Create(Guid.Parse("8EF60BCB-A795-4141-BAB6-38E5863E14A7"), "Marketing and Corporate Communications"),
                ComplianceDepartment.Create(Guid.Parse("C3DE97F2-EF7C-40AD-94EF-F88738C71C07"), "Mixta Nigeria Operations"),
                ComplianceDepartment.Create(Guid.Parse("1AC36092-DA7B-4B32-BDAC-A97FC23164CF"), "Mixta Nigeria Sales"),
                ComplianceDepartment.Create(Guid.Parse("4E7F8112-D6BF-4619-B41E-236FBA1EB541"), "Oakland Limited"),
                ComplianceDepartment.Create(Guid.Parse("93427CE2-6640-44ED-A078-320AC73E4DC2"), "ODA"),
                ComplianceDepartment.Create(Guid.Parse("9AE1D479-E587-4D46-95BA-B8E72851FC75"), "Operation Controls"),
                ComplianceDepartment.Create(Guid.Parse("199F9DE0-D08B-47EB-A96A-5B2526EB31EE"), "Platform 30"),
                ComplianceDepartment.Create(Guid.Parse("022AA7D5-7C0A-4FB3-9C8D-FF2278B289FA"), "Port Harcourt"),
                ComplianceDepartment.Create(Guid.Parse("3DDC0333-F27A-4CED-9599-6EF1EE92C3C0"), "Private Trust"),
                ComplianceDepartment.Create(Guid.Parse("AFFCEBA9-38DC-4E5F-AFB0-8B2D9EDF5EFA"), "Procurement and Administration"),
                ComplianceDepartment.Create(Guid.Parse("97C9B380-AD8F-4F41-944B-DC37B82FE85F"), "Procurement and Contracting"),
                ComplianceDepartment.Create(Guid.Parse("5E885E75-F8B3-4B3A-9017-B2E7A1122D83"), "Project Management Office"),
                ComplianceDepartment.Create(Guid.Parse("2FD39529-B005-4293-8B8F-12ED3FF87807"), "Proprietary and Principal Transactions"),
                ComplianceDepartment.Create(Guid.Parse("7165D5C6-DC08-4471-99B9-4C60DD76EC8D"), "RDP"),
                ComplianceDepartment.Create(Guid.Parse("A66BEA4E-F461-476F-9AF7-61A91C69AF99"), "Real Estate"),
                ComplianceDepartment.Create(Guid.Parse("55772580-4C93-435D-8C31-685B80B9BD3F"), "Registrars"),
                ComplianceDepartment.Create(Guid.Parse("DD059D83-0706-425F-AA33-C8D32294F7B7"), "Research"),
                ComplianceDepartment.Create(Guid.Parse("58662C2E-5A9C-43F8-8D42-FC2E93A50EB4"), "Retail Operations"),
                ComplianceDepartment.Create(Guid.Parse("040ACAF6-CCDC-4302-BAE9-95BBE7175FA7"), "RFL"),
                ComplianceDepartment.Create(Guid.Parse("F155216A-9FC1-4D29-AC25-060C116D0E1E"), "Risk Management"),
                ComplianceDepartment.Create(Guid.Parse("9D10FB74-ED81-42EC-A109-072CA0DDFDE3"), "Securities Operations "),
                ComplianceDepartment.Create(Guid.Parse("F0748176-DF02-49AF-8565-520F9C59C9A0"), "Summerville / Lakowe"),
                ComplianceDepartment.Create(Guid.Parse("5203F4DC-AB02-4DC8-85B1-B293FF9FFCBF"), "Technical / Projects"),
                ComplianceDepartment.Create(Guid.Parse("82355662-28D3-45C9-BBF4-51BE40C368D5"), "Townsville"),
                ComplianceDepartment.Create(Guid.Parse("80921FB2-5762-4149-98A1-7A990EFB2428"), "Trading / Bokerage"),
                ComplianceDepartment.Create(Guid.Parse("DA9C707E-FF33-455B-973E-FF2928D41ACA"), "Treasury"),
                ComplianceDepartment.Create(Guid.Parse("CA9277C7-59D1-4F5F-ADBF-BD036440E602"), "TSD Ltd"),
                ComplianceDepartment.Create(Guid.Parse("E98B0111-935C-41BA-BFED-00AE9CE3814F"), "Village"),
                ComplianceDepartment.Create(Guid.Parse("193306A0-16CE-4C4B-99A1-8765A8032CAC"), "Wealth & Relationship Management -Abuja"),
                ComplianceDepartment.Create(Guid.Parse("F8360FFE-E1BE-4D14-99A8-DB3A2E840F41"), "Wealth & Relationship Management -Lagos"),
                ComplianceDepartment.Create(Guid.Parse("9CB7A2C2-4D91-47C1-9C6F-17540AFA0C44"), "Wealth & Relationship Management -Port Harcourt")
            );
        }
    }
}
