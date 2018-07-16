using KKSuperMart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KKSuperMart
{
    public class MemberDetailsValidation
    {
        public static FunctionResponse ValidateMemberDetails(MemberDetails MemberDetails)
        {
            try
            {
                if (string.IsNullOrEmpty(MemberDetails.email))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter Email" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.mob))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter Mobile Number" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.fname))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter First Name " };
                }
                else if (string.IsNullOrEmpty(MemberDetails.lname))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter Last Name" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.add.street))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter Street" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.add.tole))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter Tole" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.add.dist))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter district" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.add.zone))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Enter zone" };
                }
                else if (string.IsNullOrEmpty(MemberDetails.sex))
                {
                    return new FunctionResponse() { Status = "error", Message = "Please Select Sex" };
                }
                else
                {
                    return new FunctionResponse() { Status = "ok", Message = "All fields entered correctly" };
                }
            }
            catch { return new  FunctionResponse(){Status = "error", Message = "" }; }
        }
    }
}
