﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.ENT;

/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>
/// 
namespace AddressBook.DAL
{

    public class ContactCategoryDAL:DatabaseConfig
    {
        #region Constructor
        public ContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Local Variable
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region inserst operation

        public Boolean Insert(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_Insert";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@ContactCategoryName", SqlDbType.VarChar).Value = entContactCategory.ContactCategoryName;


                        #endregion

                        objCmd.ExecuteNonQuery();

                        
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }

        #endregion

        #region update operation
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContactCategory.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactCategoryName", SqlDbType.VarChar).Value = entContactCategory.ContactCategoryName;


                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 ContactCategoryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;
                      

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region select operation

        #region selectall operation
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectAll";
                        #endregion

                        #region read  data 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                           
                                dt.Load(objSDR);

                           
                            return dt;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region selectPK operation
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
                        #endregion

                        #region read  data 
                        ContactCategoryENT entContactCategory = new ContactCategoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"].ToString());
                                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString();
                            }
                            return entContactCategory;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region SelectForDopDown operation
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
                        #endregion

                        #region read  data 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            
                                dt.Load(objSDR);
                           
                            return dt;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #endregion
    }
}