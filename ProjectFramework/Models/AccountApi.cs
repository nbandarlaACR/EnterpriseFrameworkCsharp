using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models

{
    public class AccountApi
    {
        public List<SearchResult> SearchResults { get; set; }
    }

    public class SearchResult
    {
        public string lowellReference { get; set; }
        public string clientCode { get; set; }
        public string clientName { get; set; }
        public string clientReference { get; set; }
        public double outstandingBalance { get; set; }
        public double originalBalance { get; set; }
        public double arrears { get; set; }
        public double totalPaid { get; set; }
        public string status { get; set; }
        public bool canMakePayment { get; set; }
        public bool canSetupIndividualPlan { get; set; }
        public bool canSetupIndividualCardPlan { get; set; }
        public bool canAmendPlan { get; set; }
        public bool hasArrangement { get; set; }
        public bool cardPlanCoolingOff { get; set; }
        public double regularAccountPaymentAmount { get; set; }
        public string planFrequency { get; set; }
        public string planType { get; set; }
        public bool directDebitInFlight { get; set; }
        public object lastPaymentReceived { get; set; }
        public string excludedMessage { get; set; }
        public double discountPercentage { get; set; }
        public double discountAmount { get; set; }
        public object discountExpiry { get; set; }
        public double discountedBalance { get; set; }
        public List<string> planMessages { get; set; }
        public string postcode { get; set; }
        public string dateOfBirth { get; set; }
        public string reportingCode { get; set; }
        public bool hasWebAccount { get; set; }
        public object lastSavedBudgetPlannerDate { get; set; }
        public int company { get; set; }
        public string earliestInstalmentDate { get; set; }
        public string latestPlanSetupDate { get; set; }
        public string earliestAmendInstalment { get; set; }
        public bool isWorkable { get; set; }
        public int dcaID { get; set; }
        public string dcaName { get; set; }
        public bool neverAllowPlanTransfer { get; set; }
        public bool planPendingTransfer { get; set; }
        public string planTransferredFrom { get; set; }
        public double averageSetupValue { get; set; }
    }


}
