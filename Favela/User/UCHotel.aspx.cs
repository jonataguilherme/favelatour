using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Favela.Library.Model;

namespace Favela.User
{
    public partial class UCHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetDropDownList();
            }
        }

        private void SetDropDownList()
        {
            List<Hotel> hoteisCadastrados = new List<Hotel>();

            hoteisCadastrados = Hotel.Repository.GetAll();

            foreach (Hotel hotel in hoteisCadastrados)
            {
                
            }

        }

        protected void btnConfirma(object sender, EventArgs e)
        {
            Response.Redirect("?User=UCHotel");
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void gvHotGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}