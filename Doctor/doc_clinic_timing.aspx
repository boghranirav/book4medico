<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_clinic_timing.aspx.cs" Inherits="Doctor_doc_clinic_timing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1 class="page-header">Clinic Timing</h1>

<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

  <div class="row">
			    <div class="col-md-12">

               
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">Clinic Schedule</h4>
                        </div>
                        <div class="panel-body">

                                <div >
                                        <label class="col-md-2 col-sm-2 "><font size="4">Select Clinic :</font></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="doc_clinic" runat="server" class="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="doc_clinic_SelectedIndexChanged">
                                            <asp:ListItem disabled Selected>SELECT CLINIC</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="doc_clinic" ErrorMessage="*Select Clinic." ForeColor="Red" InitialValue="SELECT CLINIC"></asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                        
                                </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           
                            <ContentTemplate>
                            
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        
                                        <ContentTemplate>
                                        
                                <div class="form-group">
                                    <table class="table table-bordered">

                                        <thead>
                                            <tr>
                                                <th>Day</th>
                                                <th>First Half</th>
                                                <th>Second Half</th>
                                                <th>Holiday</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        
                                            <tr>
                                                <td>Monday</td>
                                                <td>
                                    
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
                                                                
											                    <input id="timepickermo1"  type="text" class="form-control timepickermo1" runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                                                
										                    </div>
                                                            
									                    </div>
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickermo2" type="text" class="form-control timepickermo2" runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                   
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickermo3" type="text" class="form-control timepickermo3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                                                
										                    </div>
                                                            
									                    </div>
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickermo4" type="text" class="form-control timepickermo4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day1" runat="server" AutoPostBack="True" 
                                                      oncheckedchanged="cb_day1_CheckedChanged1"/></td>
                                            </tr>
                                           

                                  
                                            <tr>
                                                <td>Tuesday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickertu1" type="text" class="form-control timepickertu1"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickertu2" type="text" class="form-control timepickertu2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                   
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickertu3" type="text" class="form-control timepickertu3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickertu4" type="text" class="form-control timepickertu4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day2" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day2_CheckedChanged" /></td>
                                            </tr>
                                     
                                            <tr>
                                                <td>Wednesday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerwe1" type="text" class="form-control timepickerwe1"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerwe2" type="text" class="form-control timepickerwe2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerwe3" type="text" class="form-control timepickerwe3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerwe4" type="text" class="form-control timepickerwe4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day3" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day3_CheckedChanged" /></td>
                                            </tr>
                                            <tr>
                                                <td>Thursday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerthu1" type="text" class="form-control timepickerthu1"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerthu2" type="text" class="form-control timepickerthu2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerthu3" type="text" class="form-control timepickerthu3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerthu4" type="text" class="form-control timepickerthu4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day4" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day4_CheckedChanged" /></td>
                                            </tr><tr>
                                                <td>Friday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerfri1" type="text" class="form-control timepickerfri1"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerfri2" type="text" class="form-control timepickerfri2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerfri3" type="text" class="form-control timepickerfri3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickerfri4" type="text" class="form-control timepickerfri4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day5" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day5_CheckedChanged" /></td>
                                            </tr><tr>
                                                <td>Saturday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersat1" type="text" class="form-control timepickersat1" runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersat2" type="text" class="form-control timepickersat2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersat3" type="text" class="form-control timepickersat3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersat4" type="text" class="form-control timepickersat4"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day6" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day6_CheckedChanged" /></td>
                                            </tr><tr>
                                                <td>Sunday</td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersun1" type="text" class="form-control timepickersun1"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersun2" type="text" class="form-control timepickersun2"  runat="server" style="width:2.1cm"/>
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td>
                                                    <div>
									                    <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersun3" type="text" class="form-control timepickersun3"  runat="server" style="width:2.1cm"/>
                                                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
                                                        
                                                        <div class="col-md-4">
										                    <div class="input-group bootstrap-timepicker">
											                    <input id="timepickersun4" type="text" class="form-control timepickersun4" runat="server" style="width:2.1cm"/>
                                                               
											                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
										                    </div>
									                    </div>
								                   </div>
                                                </td>
                                                <td align="center"><asp:CheckBox ID="cb_day7" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="cb_day7_CheckedChanged" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
                            </div>

                             </ContentTemplate>
                             <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="cb_day1" EventName="checkedchanged" />
                                            
                                        </Triggers>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="cb_day2" EventName="checkedchanged" />
                                            <asp:AsyncPostBackTrigger ControlID="cb_day3" EventName="checkedchanged" />
                                            <asp:AsyncPostBackTrigger ControlID="cb_day4" EventName="checkedchanged" />
                                            <asp:AsyncPostBackTrigger ControlID="cb_day5" EventName="checkedchanged" />
                                            <asp:AsyncPostBackTrigger ControlID="cb_day6" EventName="checkedchanged" />
                                            <asp:AsyncPostBackTrigger ControlID="cb_day7" EventName="checkedchanged" />
                                        </Triggers>
                            </asp:UpdatePanel>

                             <div style="width:1080px">
                             
                                    <label class="col-md-4 col-sm-3"><font size="4">Average Time To Each Patient :</font></label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="tb_minutes" runat="server" CssClass="form-control" placeholder="Minutes"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_minutes" ErrorMessage="*Enter Average Time." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Enter Valid Average Time." ValidationExpression="[0-9]{2}" ForeColor="Red" ControlToValidate="tb_minutes"></asp:RegularExpressionValidator>

                                        <ajaxToolkit:AutoCompleteExtender ServiceMethod="GetProductList" 
                                            MinimumPrefixLength="1"
                                            CompletionInterval="0" EnableCaching="false" CompletionSetCount="10" 
                                            TargetControlID="tb_minutes"
                                            ID="autoCompleteExtender1" runat="server" FirstRowSelected = "false">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        
                                        
                                        <br />
                                    </div>
                                          
                            </div>

                            
                            <div>
                                <div>
									    <div class="col-md-6">
                                            <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" onclick="submit_Click" 
                                             />
									    </div>
						        </div>
                            </div>
                            </ContentTemplate>
                             <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="doc_clinic" EventName="selectedindexchanged"/>
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
    
</form>

</asp:Content>

