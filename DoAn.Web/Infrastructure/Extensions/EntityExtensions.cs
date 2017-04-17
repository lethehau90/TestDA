using DoAn.Model.Models;
using DoAn.Web.Models;

namespace DoAn.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        //UpdateControlPanel
        public static void UpdateControlPanel(this ControlPanel controlPanel, ControlPanelViewModel controlPanelViewModel)
        {
            controlPanel.ID = controlPanelViewModel.ID;
            controlPanel.Name = controlPanelViewModel.Name;
            controlPanel.Status = controlPanelViewModel.Status;
        }

        //UpdateCustomImage
        public static void UpdateCustomImage(this CustomImage customImage, CustomImageViewModel customImageViewModel)
        {
            customImage.ID = customImageViewModel.ID;
            customImage.Type = customImageViewModel.Type;
            customImage.Images = customImageViewModel.Images;

            customImage.CreatedDate = customImageViewModel.CreatedDate;
            customImage.UpdateDate = customImageViewModel.UpdateDate;
            customImage.CreatedBy = customImageViewModel.CreatedBy;
            customImage.UpdateBy = customImageViewModel.UpdateBy;
            customImage.Status = customImageViewModel.Status;
        }

        //UpdateCustomHeader
        public static void UpdateCustomHeader(this CustomHeader customHeader, CustomHeaderViewModel customHeaderViewModel)
        {
            customHeader.ID = customHeaderViewModel.ID;
            customHeader.Type = customHeaderViewModel.Type;
            customHeader.Color = customHeaderViewModel.Color;
            customHeader.Content = customHeaderViewModel.Content;

            customHeader.CreatedDate = customHeaderViewModel.CreatedDate;
            customHeader.UpdateDate = customHeaderViewModel.UpdateDate;
            customHeader.CreatedBy = customHeaderViewModel.CreatedBy;
            customHeader.UpdateBy = customHeaderViewModel.UpdateBy;
            customHeader.Status = customHeaderViewModel.Status;
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

            donation.CreatedDate = donationViewModel.CreatedDate;
            donation.UpdateDate = donationViewModel.UpdateDate;
            donation.CreatedBy = donationViewModel.CreatedBy;
            donation.UpdateBy = donationViewModel.UpdateBy;
            donation.Status = donationViewModel.Status;
        }

        //UpdateLaudatory
        public static void UpdateLaudatory(this Laudatory laudatory, LaudatoryViewModel laudatoryViewModel)
        {
            laudatory.ID = laudatoryViewModel.ID;
            laudatory.Name = laudatoryViewModel.Name;
            laudatory.Class = laudatoryViewModel.Class;
            laudatory.Note = laudatoryViewModel.Note;
            laudatory.Appellation = laudatoryViewModel.Appellation;
            laudatory.CountBook = laudatoryViewModel.CountBook;

            laudatory.CreatedDate = laudatoryViewModel.CreatedDate;
            laudatory.UpdateDate = laudatoryViewModel.UpdateDate;
            laudatory.CreatedBy = laudatoryViewModel.CreatedBy;
            laudatory.UpdateBy = laudatoryViewModel.UpdateBy;
            laudatory.Status = laudatoryViewModel.Status;
        }
    }
}