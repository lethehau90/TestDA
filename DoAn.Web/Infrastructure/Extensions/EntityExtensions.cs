using DoAn.Model.Models;
using DoAn.Web.Models;

namespace DoAn.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        //UpdateControlPanel
        public static void UpdateControlPanel(this ControlPanel controlPanel,  ControlPanelViewModel controlPanelViewModel)
        {
            controlPanel.ID = controlPanelViewModel.ID;
            controlPanel.Name = controlPanelViewModel.Name;
            controlPanel.Status = controlPanelViewModel.Status;
        }

        //UpdateDonation
        public static void UpdateDonation(this Donation donation, DonationViewModel donationViewModel)
        {
            donation.ID = donationViewModel.ID;
            donation.Name = donationViewModel.Name;
            donation.Note = donationViewModel.Note;
            donation.Price = donationViewModel.Price;
            donation.Class = donationViewModel.Class;
            donation.Address = donationViewModel.Address;
        }
    }
}