﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddressBook.BAL;

public partial class Content_AdminPanel_BloodGroup_BloodGroupList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewBloodGroup();
        }
    }
    #endregion

    #region Fill BloodGroup Grid View
    private void FillGridViewBloodGroup()
    {
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        gvBloodGroup.DataSource = balBloodGroup.SelectAll();
        gvBloodGroup.DataBind();
    }
    #endregion

    #region Button: Add BloodGroup
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/BloodGroup/BloodGroupAddEdit.aspx");
    }
    #endregion

    #region Button: Delete Contact Category 
    private void DeleteBloodGroup(SqlInt32 BloodGroupID)
    {
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        if (balBloodGroup.Delete(BloodGroupID))
        {
            FillGridViewBloodGroup();
        }
        else
        {
            lblErrorMessage.Text = balBloodGroup.Message;
        }
    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvBloodGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteBloodGroup(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewBloodGroup();
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }
    }
    #endregion
}