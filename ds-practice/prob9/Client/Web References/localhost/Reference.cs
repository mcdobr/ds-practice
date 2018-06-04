﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Client.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="HumanResourcesSoap", Namespace="http://tempuri.org/")]
    public partial class HumanResources : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddManagerOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddEmployeeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetManagerOfOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetEmployeesOfOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public HumanResources() {
            this.Url = global::Client.Properties.Settings.Default.Client_localhost_HumanResources;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddManagerCompletedEventHandler AddManagerCompleted;
        
        /// <remarks/>
        public event AddEmployeeCompletedEventHandler AddEmployeeCompleted;
        
        /// <remarks/>
        public event GetManagerOfCompletedEventHandler GetManagerOfCompleted;
        
        /// <remarks/>
        public event GetEmployeesOfCompletedEventHandler GetEmployeesOfCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddManager", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddManager(Employee e) {
            this.Invoke("AddManager", new object[] {
                        e});
        }
        
        /// <remarks/>
        public void AddManagerAsync(Employee e) {
            this.AddManagerAsync(e, null);
        }
        
        /// <remarks/>
        public void AddManagerAsync(Employee e, object userState) {
            if ((this.AddManagerOperationCompleted == null)) {
                this.AddManagerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddManagerOperationCompleted);
            }
            this.InvokeAsync("AddManager", new object[] {
                        e}, this.AddManagerOperationCompleted, userState);
        }
        
        private void OnAddManagerOperationCompleted(object arg) {
            if ((this.AddManagerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddManagerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddEmployee", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddEmployee(Employee m, Employee e) {
            this.Invoke("AddEmployee", new object[] {
                        m,
                        e});
        }
        
        /// <remarks/>
        public void AddEmployeeAsync(Employee m, Employee e) {
            this.AddEmployeeAsync(m, e, null);
        }
        
        /// <remarks/>
        public void AddEmployeeAsync(Employee m, Employee e, object userState) {
            if ((this.AddEmployeeOperationCompleted == null)) {
                this.AddEmployeeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddEmployeeOperationCompleted);
            }
            this.InvokeAsync("AddEmployee", new object[] {
                        m,
                        e}, this.AddEmployeeOperationCompleted, userState);
        }
        
        private void OnAddEmployeeOperationCompleted(object arg) {
            if ((this.AddEmployeeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddEmployeeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetManagerOf", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Employee GetManagerOf(Employee e) {
            object[] results = this.Invoke("GetManagerOf", new object[] {
                        e});
            return ((Employee)(results[0]));
        }
        
        /// <remarks/>
        public void GetManagerOfAsync(Employee e) {
            this.GetManagerOfAsync(e, null);
        }
        
        /// <remarks/>
        public void GetManagerOfAsync(Employee e, object userState) {
            if ((this.GetManagerOfOperationCompleted == null)) {
                this.GetManagerOfOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetManagerOfOperationCompleted);
            }
            this.InvokeAsync("GetManagerOf", new object[] {
                        e}, this.GetManagerOfOperationCompleted, userState);
        }
        
        private void OnGetManagerOfOperationCompleted(object arg) {
            if ((this.GetManagerOfCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetManagerOfCompleted(this, new GetManagerOfCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetEmployeesOf", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Employee[] GetEmployeesOf(Employee e) {
            object[] results = this.Invoke("GetEmployeesOf", new object[] {
                        e});
            return ((Employee[])(results[0]));
        }
        
        /// <remarks/>
        public void GetEmployeesOfAsync(Employee e) {
            this.GetEmployeesOfAsync(e, null);
        }
        
        /// <remarks/>
        public void GetEmployeesOfAsync(Employee e, object userState) {
            if ((this.GetEmployeesOfOperationCompleted == null)) {
                this.GetEmployeesOfOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetEmployeesOfOperationCompleted);
            }
            this.InvokeAsync("GetEmployeesOf", new object[] {
                        e}, this.GetEmployeesOfOperationCompleted, userState);
        }
        
        private void OnGetEmployeesOfOperationCompleted(object arg) {
            if ((this.GetEmployeesOfCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetEmployeesOfCompleted(this, new GetEmployeesOfCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Employee {
        
        private string nameField;
        
        private Employee managerField;
        
        private Employee[] subordinatesField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public Employee Manager {
            get {
                return this.managerField;
            }
            set {
                this.managerField = value;
            }
        }
        
        /// <remarks/>
        public Employee[] Subordinates {
            get {
                return this.subordinatesField;
            }
            set {
                this.subordinatesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void AddManagerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void AddEmployeeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void GetManagerOfCompletedEventHandler(object sender, GetManagerOfCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetManagerOfCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetManagerOfCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Employee Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Employee)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void GetEmployeesOfCompletedEventHandler(object sender, GetEmployeesOfCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetEmployeesOfCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetEmployeesOfCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Employee[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Employee[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591