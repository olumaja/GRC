namespace GrcApi.Modules.RiskManagement
{
    public class RiskManagementEmailTemplate
    {
        public static string NewEventEmail = "<table>\r\n    <tr>\r\n        <td>Event Description</td>\r\n        <td>{0}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Event Number</td>\r\n        <td>{1}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Event Identifier</td>\r\n        <td>{2}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Event Location</td>\r\n        <td>{3}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Date of Occurence</td>\r\n        <td>{4}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Estimated Loss</td>\r\n        <td>{5}</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Rationale for Estimated Loss</td>\r\n        <td>{6}</td>\r\n    </tr>\r\n</table>";
    }
}
