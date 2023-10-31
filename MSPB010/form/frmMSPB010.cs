using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using MSPB.Common;
using System.Drawing;
using MSPB.MSPB010.dao;
using System.Data;

namespace MSPB.MSPB010.form
{

    /// <summary>
    /// 検索画面
    /// </summary>
    class frmMSPB010 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblComment12;
        private System.Windows.Forms.TextBox txtShippingDate;
        private System.Windows.Forms.Label lblShippingDate;
        private System.Windows.Forms.Label lblComment11;
        private System.Windows.Forms.TextBox txtTrackNo;
        private System.Windows.Forms.Label lblTrackNo;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label lblReturnPlace;
        private System.Windows.Forms.Label lblComment8;
        private System.Windows.Forms.TextBox txtResponseDate;
        private System.Windows.Forms.Label lblResponseDate;
        private System.Windows.Forms.Label lblComment7;
        private System.Windows.Forms.TextBox txtStoragePeriod;
        private System.Windows.Forms.Label lblStoragePeriod;
        private System.Windows.Forms.ComboBox CmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblComment6;
        private System.Windows.Forms.TextBox txtReportDate;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.Label lblComment5;
        private System.Windows.Forms.TextBox txtPersonalBelongingsInfo;
        private System.Windows.Forms.Label lblPersonalBelongingsInfo;
        private System.Windows.Forms.Label lblComment4;
        private System.Windows.Forms.TextBox txtStorageReferenceDate;
        private System.Windows.Forms.Label lblStorageReferenceDate;
        private System.Windows.Forms.Label lblComment3;
        private System.Windows.Forms.TextBox txtContractNo;
        private System.Windows.Forms.Label lblEscalationResponse;
        private System.Windows.Forms.Label lblComment2;
        private System.Windows.Forms.ComboBox CmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblComment1;
        private System.Windows.Forms.TextBox txtRegistDate;
        private System.Windows.Forms.Label lblRegistDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblContractNo;
        private System.Windows.Forms.Label lblControlNo;
        private System.Windows.Forms.ComboBox CmbEscalationResponse;
        private System.Windows.Forms.ComboBox CmbReturnPlace;        
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Search_List;
        private System.Windows.Forms.Label header0;


        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblComment12 = new System.Windows.Forms.Label();
            this.txtShippingDate = new System.Windows.Forms.TextBox();
            this.lblShippingDate = new System.Windows.Forms.Label();
            this.lblComment11 = new System.Windows.Forms.Label();
            this.txtTrackNo = new System.Windows.Forms.TextBox();
            this.lblTrackNo = new System.Windows.Forms.Label();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.lblReturnPlace = new System.Windows.Forms.Label();
            this.lblComment8 = new System.Windows.Forms.Label();
            this.txtResponseDate = new System.Windows.Forms.TextBox();
            this.lblResponseDate = new System.Windows.Forms.Label();
            this.lblComment7 = new System.Windows.Forms.Label();
            this.txtStoragePeriod = new System.Windows.Forms.TextBox();
            this.lblStoragePeriod = new System.Windows.Forms.Label();
            this.CmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblComment6 = new System.Windows.Forms.Label();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.lblComment5 = new System.Windows.Forms.Label();
            this.txtPersonalBelongingsInfo = new System.Windows.Forms.TextBox();
            this.lblPersonalBelongingsInfo = new System.Windows.Forms.Label();
            this.lblComment4 = new System.Windows.Forms.Label();
            this.txtStorageReferenceDate = new System.Windows.Forms.TextBox();
            this.lblStorageReferenceDate = new System.Windows.Forms.Label();
            this.lblComment3 = new System.Windows.Forms.Label();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.lblEscalationResponse = new System.Windows.Forms.Label();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.CmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.txtRegistDate = new System.Windows.Forms.TextBox();
            this.lblRegistDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbEscalationResponse = new System.Windows.Forms.ComboBox();
            this.CmbReturnPlace = new System.Windows.Forms.ComboBox();
            this.lblContractNo = new System.Windows.Forms.Label();
            this.lblControlNo = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Search_List = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Search_List)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1034, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(377, 15);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(258, 36);
            this.header0.TabIndex = 0;
            this.header0.Text = "MS　私物返却管理DB";
            // 
            // header1
            // 
            this.header1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.header1.AutoSize = true;
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(484, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(63, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "検索";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(916, 688);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(850, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 31);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblComment12
            // 
            this.lblComment12.AutoSize = true;
            this.lblComment12.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment12.Location = new System.Drawing.Point(325, 297);
            this.lblComment12.Name = "lblComment12";
            this.lblComment12.Size = new System.Drawing.Size(159, 20);
            this.lblComment12.TabIndex = 85;
            this.lblComment12.Text = "（前方一致 yyyymmdd）";
            // 
            // txtShippingDate
            // 
            this.txtShippingDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtShippingDate.Location = new System.Drawing.Point(155, 295);
            this.txtShippingDate.MaxLength = 8;
            this.txtShippingDate.Name = "txtShippingDate";
            this.txtShippingDate.Size = new System.Drawing.Size(159, 19);
            this.txtShippingDate.TabIndex = 14;
            // 
            // lblShippingDate
            // 
            this.lblShippingDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblShippingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShippingDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShippingDate.Location = new System.Drawing.Point(39, 295);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(110, 19);
            this.lblShippingDate.TabIndex = 83;
            this.lblShippingDate.Text = "出　　荷　　日";
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment11
            // 
            this.lblComment11.AutoSize = true;
            this.lblComment11.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment11.Location = new System.Drawing.Point(325, 275);
            this.lblComment11.Name = "lblComment11";
            this.lblComment11.Size = new System.Drawing.Size(87, 20);
            this.lblComment11.TabIndex = 82;
            this.lblComment11.Text = "（前方一致）";
            // 
            // txtTrackNo
            // 
            this.txtTrackNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTrackNo.Location = new System.Drawing.Point(155, 273);
            this.txtTrackNo.MaxLength = 20;
            this.txtTrackNo.Name = "txtTrackNo";
            this.txtTrackNo.Size = new System.Drawing.Size(159, 19);
            this.txtTrackNo.TabIndex = 13;
            // 
            // lblTrackNo
            // 
            this.lblTrackNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTrackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrackNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTrackNo.Location = new System.Drawing.Point(39, 273);
            this.lblTrackNo.Name = "lblTrackNo";
            this.lblTrackNo.Size = new System.Drawing.Size(110, 19);
            this.lblTrackNo.TabIndex = 80;
            this.lblTrackNo.Text = "追　跡　番　号";
            this.lblTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtControlNo
            // 
            this.txtControlNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtControlNo.Location = new System.Drawing.Point(155, 53);
            this.txtControlNo.MaxLength = 20;
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(159, 19);
            this.txtControlNo.TabIndex = 3;
            // 
            // lblReturnPlace
            // 
            this.lblReturnPlace.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblReturnPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnPlace.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReturnPlace.Location = new System.Drawing.Point(39, 229);
            this.lblReturnPlace.Name = "lblReturnPlace";
            this.lblReturnPlace.Size = new System.Drawing.Size(110, 19);
            this.lblReturnPlace.TabIndex = 74;
            this.lblReturnPlace.Text = "返　　却　　先";
            this.lblReturnPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment8
            // 
            this.lblComment8.AutoSize = true;
            this.lblComment8.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment8.Location = new System.Drawing.Point(325, 210);
            this.lblComment8.Name = "lblComment8";
            this.lblComment8.Size = new System.Drawing.Size(159, 20);
            this.lblComment8.TabIndex = 73;
            this.lblComment8.Text = "（前方一致 yyyymmdd）";
            // 
            // txtResponseDate
            // 
            this.txtResponseDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtResponseDate.Location = new System.Drawing.Point(155, 207);
            this.txtResponseDate.MaxLength = 8;
            this.txtResponseDate.Name = "txtResponseDate";
            this.txtResponseDate.Size = new System.Drawing.Size(159, 19);
            this.txtResponseDate.TabIndex = 10;
            // 
            // lblResponseDate
            // 
            this.lblResponseDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblResponseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResponseDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblResponseDate.Location = new System.Drawing.Point(39, 207);
            this.lblResponseDate.Name = "lblResponseDate";
            this.lblResponseDate.Size = new System.Drawing.Size(110, 19);
            this.lblResponseDate.TabIndex = 71;
            this.lblResponseDate.Text = "回　　答　　日";
            this.lblResponseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment7
            // 
            this.lblComment7.AutoSize = true;
            this.lblComment7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment7.Location = new System.Drawing.Point(325, 188);
            this.lblComment7.Name = "lblComment7";
            this.lblComment7.Size = new System.Drawing.Size(159, 20);
            this.lblComment7.TabIndex = 70;
            this.lblComment7.Text = "（前方一致 yyyymmdd）";
            // 
            // txtStoragePeriod
            // 
            this.txtStoragePeriod.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtStoragePeriod.Location = new System.Drawing.Point(155, 185);
            this.txtStoragePeriod.MaxLength = 8;
            this.txtStoragePeriod.Name = "txtStoragePeriod";
            this.txtStoragePeriod.Size = new System.Drawing.Size(159, 19);
            this.txtStoragePeriod.TabIndex = 9;
            // 
            // lblStoragePeriod
            // 
            this.lblStoragePeriod.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblStoragePeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStoragePeriod.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStoragePeriod.Location = new System.Drawing.Point(39, 185);
            this.lblStoragePeriod.Name = "lblStoragePeriod";
            this.lblStoragePeriod.Size = new System.Drawing.Size(110, 19);
            this.lblStoragePeriod.TabIndex = 68;
            this.lblStoragePeriod.Text = "保　管　期　限";
            this.lblStoragePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbStatus
            // 
            this.CmbStatus.FormattingEnabled = true;
            this.CmbStatus.Location = new System.Drawing.Point(155, 96);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Size = new System.Drawing.Size(159, 20);
            this.CmbStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus.Location = new System.Drawing.Point(39, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 19);
            this.lblStatus.TabIndex = 66;
            this.lblStatus.Text = "ス テ ー タ ス";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment6
            // 
            this.lblComment6.AutoSize = true;
            this.lblComment6.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment6.Location = new System.Drawing.Point(325, 144);
            this.lblComment6.Name = "lblComment6";
            this.lblComment6.Size = new System.Drawing.Size(159, 20);
            this.lblComment6.TabIndex = 65;
            this.lblComment6.Text = "（前方一致 yyyymmdd）";
            // 
            // txtReportDate
            // 
            this.txtReportDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReportDate.Location = new System.Drawing.Point(155, 141);
            this.txtReportDate.MaxLength = 8;
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.Size = new System.Drawing.Size(159, 19);
            this.txtReportDate.TabIndex = 7;
            // 
            // lblReportDate
            // 
            this.lblReportDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReportDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReportDate.Location = new System.Drawing.Point(39, 141);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(110, 19);
            this.lblReportDate.TabIndex = 63;
            this.lblReportDate.Text = "報　　告　　日";
            this.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment5
            // 
            this.lblComment5.AutoSize = true;
            this.lblComment5.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment5.Location = new System.Drawing.Point(635, 121);
            this.lblComment5.Name = "lblComment5";
            this.lblComment5.Size = new System.Drawing.Size(87, 20);
            this.lblComment5.TabIndex = 62;
            this.lblComment5.Text = "（部分一致）";
            // 
            // txtPersonalBelongingsInfo
            // 
            this.txtPersonalBelongingsInfo.Location = new System.Drawing.Point(155, 119);
            this.txtPersonalBelongingsInfo.MaxLength = 60;
            this.txtPersonalBelongingsInfo.Name = "txtPersonalBelongingsInfo";
            this.txtPersonalBelongingsInfo.Size = new System.Drawing.Size(474, 19);
            this.txtPersonalBelongingsInfo.TabIndex = 6;
            // 
            // lblPersonalBelongingsInfo
            // 
            this.lblPersonalBelongingsInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblPersonalBelongingsInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPersonalBelongingsInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonalBelongingsInfo.Location = new System.Drawing.Point(39, 119);
            this.lblPersonalBelongingsInfo.Name = "lblPersonalBelongingsInfo";
            this.lblPersonalBelongingsInfo.Size = new System.Drawing.Size(110, 19);
            this.lblPersonalBelongingsInfo.TabIndex = 60;
            this.lblPersonalBelongingsInfo.Text = "私　物　情　報";
            this.lblPersonalBelongingsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment4
            // 
            this.lblComment4.AutoSize = true;
            this.lblComment4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment4.Location = new System.Drawing.Point(325, 165);
            this.lblComment4.Name = "lblComment4";
            this.lblComment4.Size = new System.Drawing.Size(159, 20);
            this.lblComment4.TabIndex = 59;
            this.lblComment4.Text = "（前方一致 yyyymmdd）";
            // 
            // txtStorageReferenceDate
            // 
            this.txtStorageReferenceDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtStorageReferenceDate.Location = new System.Drawing.Point(155, 163);
            this.txtStorageReferenceDate.MaxLength = 8;
            this.txtStorageReferenceDate.Name = "txtStorageReferenceDate";
            this.txtStorageReferenceDate.Size = new System.Drawing.Size(159, 19);
            this.txtStorageReferenceDate.TabIndex = 8;
            // 
            // lblStorageReferenceDate
            // 
            this.lblStorageReferenceDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblStorageReferenceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStorageReferenceDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStorageReferenceDate.Location = new System.Drawing.Point(39, 163);
            this.lblStorageReferenceDate.Name = "lblStorageReferenceDate";
            this.lblStorageReferenceDate.Size = new System.Drawing.Size(110, 19);
            this.lblStorageReferenceDate.TabIndex = 57;
            this.lblStorageReferenceDate.Text = "保 管 基 準 日";
            this.lblStorageReferenceDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment3
            // 
            this.lblComment3.AutoSize = true;
            this.lblComment3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment3.Location = new System.Drawing.Point(325, 78);
            this.lblComment3.Name = "lblComment3";
            this.lblComment3.Size = new System.Drawing.Size(87, 20);
            this.lblComment3.TabIndex = 56;
            this.lblComment3.Text = "（部分一致）";
            // 
            // txtContractNo
            // 
            this.txtContractNo.Location = new System.Drawing.Point(155, 75);
            this.txtContractNo.MaxLength = 60;
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.Size = new System.Drawing.Size(159, 19);
            this.txtContractNo.TabIndex = 4;
            // 
            // lblEscalationResponse
            // 
            this.lblEscalationResponse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEscalationResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEscalationResponse.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEscalationResponse.Location = new System.Drawing.Point(39, 251);
            this.lblEscalationResponse.Name = "lblEscalationResponse";
            this.lblEscalationResponse.Size = new System.Drawing.Size(110, 19);
            this.lblEscalationResponse.TabIndex = 54;
            this.lblEscalationResponse.Text = "エスカレ 回 答";
            this.lblEscalationResponse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment2
            // 
            this.lblComment2.AutoSize = true;
            this.lblComment2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment2.Location = new System.Drawing.Point(325, 55);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(87, 20);
            this.lblComment2.TabIndex = 53;
            this.lblComment2.Text = "（前方一致）";
            // 
            // CmbProductType
            // 
            this.CmbProductType.FormattingEnabled = true;
            this.CmbProductType.Location = new System.Drawing.Point(155, 30);
            this.CmbProductType.Name = "CmbProductType";
            this.CmbProductType.Size = new System.Drawing.Size(159, 20);
            this.CmbProductType.TabIndex = 2;
            // 
            // lblProductType
            // 
            this.lblProductType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProductType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductType.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProductType.Location = new System.Drawing.Point(39, 31);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(110, 19);
            this.lblProductType.TabIndex = 49;
            this.lblProductType.Text = "種　　　　　別";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment1.Location = new System.Drawing.Point(325, 12);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(159, 20);
            this.lblComment1.TabIndex = 48;
            this.lblComment1.Text = "（前方一致 yyyymmdd）";
            // 
            // txtRegistDate
            // 
            this.txtRegistDate.Location = new System.Drawing.Point(155, 9);
            this.txtRegistDate.MaxLength = 8;
            this.txtRegistDate.Name = "txtRegistDate";
            this.txtRegistDate.Size = new System.Drawing.Size(159, 19);
            this.txtRegistDate.TabIndex = 1;
            // 
            // lblRegistDate
            // 
            this.lblRegistDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRegistDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegistDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistDate.Location = new System.Drawing.Point(39, 9);
            this.lblRegistDate.Name = "lblRegistDate";
            this.lblRegistDate.Size = new System.Drawing.Size(110, 19);
            this.lblRegistDate.TabIndex = 46;
            this.lblRegistDate.Text = "登　　録　　日";
            this.lblRegistDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbEscalationResponse);
            this.panel1.Controls.Add(this.CmbReturnPlace);
            this.panel1.Controls.Add(this.lblContractNo);
            this.panel1.Controls.Add(this.lblControlNo);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblComment12);
            this.panel1.Controls.Add(this.txtShippingDate);
            this.panel1.Controls.Add(this.lblShippingDate);
            this.panel1.Controls.Add(this.lblComment11);
            this.panel1.Controls.Add(this.txtTrackNo);
            this.panel1.Controls.Add(this.lblTrackNo);
            this.panel1.Controls.Add(this.txtControlNo);
            this.panel1.Controls.Add(this.lblReturnPlace);
            this.panel1.Controls.Add(this.lblComment8);
            this.panel1.Controls.Add(this.txtResponseDate);
            this.panel1.Controls.Add(this.lblResponseDate);
            this.panel1.Controls.Add(this.lblComment7);
            this.panel1.Controls.Add(this.txtStoragePeriod);
            this.panel1.Controls.Add(this.lblStoragePeriod);
            this.panel1.Controls.Add(this.CmbStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblComment6);
            this.panel1.Controls.Add(this.txtReportDate);
            this.panel1.Controls.Add(this.lblReportDate);
            this.panel1.Controls.Add(this.lblComment5);
            this.panel1.Controls.Add(this.txtPersonalBelongingsInfo);
            this.panel1.Controls.Add(this.lblPersonalBelongingsInfo);
            this.panel1.Controls.Add(this.lblComment4);
            this.panel1.Controls.Add(this.txtStorageReferenceDate);
            this.panel1.Controls.Add(this.lblStorageReferenceDate);
            this.panel1.Controls.Add(this.lblComment3);
            this.panel1.Controls.Add(this.txtContractNo);
            this.panel1.Controls.Add(this.lblEscalationResponse);
            this.panel1.Controls.Add(this.lblComment2);
            this.panel1.Controls.Add(this.CmbProductType);
            this.panel1.Controls.Add(this.lblProductType);
            this.panel1.Controls.Add(this.lblComment1);
            this.panel1.Controls.Add(this.txtRegistDate);
            this.panel1.Controls.Add(this.lblRegistDate);
            this.panel1.Location = new System.Drawing.Point(45, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 325);
            this.panel1.TabIndex = 90;
            // 
            // CmbEscalationResponse
            // 
            this.CmbEscalationResponse.FormattingEnabled = true;
            this.CmbEscalationResponse.Location = new System.Drawing.Point(155, 250);
            this.CmbEscalationResponse.Name = "CmbEscalationResponse";
            this.CmbEscalationResponse.Size = new System.Drawing.Size(159, 20);
            this.CmbEscalationResponse.TabIndex = 12;
            // 
            // CmbReturnPlace
            // 
            this.CmbReturnPlace.FormattingEnabled = true;
            this.CmbReturnPlace.Location = new System.Drawing.Point(155, 229);
            this.CmbReturnPlace.Name = "CmbReturnPlace";
            this.CmbReturnPlace.Size = new System.Drawing.Size(159, 20);
            this.CmbReturnPlace.TabIndex = 11;
            // 
            // lblContractNo
            // 
            this.lblContractNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblContractNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContractNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractNo.Location = new System.Drawing.Point(39, 75);
            this.lblContractNo.Name = "lblContractNo";
            this.lblContractNo.Size = new System.Drawing.Size(110, 19);
            this.lblContractNo.TabIndex = 91;
            this.lblContractNo.Text = "証　券　番　号";
            this.lblContractNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblControlNo
            // 
            this.lblControlNo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblControlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblControlNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblControlNo.Location = new System.Drawing.Point(39, 53);
            this.lblControlNo.Name = "lblControlNo";
            this.lblControlNo.Size = new System.Drawing.Size(110, 19);
            this.lblControlNo.TabIndex = 90;
            this.lblControlNo.Text = "管　理　番　号";
            this.lblControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCount.Location = new System.Drawing.Point(874, 3);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(137, 24);
            this.lblCount.TabIndex = 91;
            this.lblCount.Text = "件";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_Search_List);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblCount);
            this.panel2.Location = new System.Drawing.Point(-1, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 256);
            this.panel2.TabIndex = 93;
            // 
            // dataGridView_Search_List
            // 
            this.dataGridView_Search_List.AllowUserToAddRows = false;
            this.dataGridView_Search_List.AllowUserToResizeColumns = false;
            this.dataGridView_Search_List.AllowUserToResizeRows = false;
            this.dataGridView_Search_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Search_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Search_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Search_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Search_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Search_List.Location = new System.Drawing.Point(16, 29);
            this.dataGridView_Search_List.Name = "dataGridView_Search_List";
            this.dataGridView_Search_List.ReadOnly = true;
            this.dataGridView_Search_List.RowHeadersVisible = false;
            this.dataGridView_Search_List.RowTemplate.Height = 21;
            this.dataGridView_Search_List.Size = new System.Drawing.Size(1030, 207);
            this.dataGridView_Search_List.TabIndex = 0;
            this.dataGridView_Search_List.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 93;
            this.label1.Text = "一覧表示";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMSPB010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1056, 736);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB010";
            this.Text = "MS 私物返却管理DB 検索";
            this.Load += new System.EventHandler(this.frmMSPB010_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Search_List)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ユーザ名
        /// </summary>
        private static string _userName;

        daofrmMSPB010 dao = null;

        // エスカレテーブル用DataTable
        DataTable dtEscalation = new DataTable();
        // エスカレ回答プルダウン用DataTable
        DataTable dtStatus = null;

        private List<ResponseTMPEntity> dtos = new List<ResponseTMPEntity>();

        public sealed class Escalation_Search_List
        {
            public string REGIST_DATE { get; set; }
            public string PRODUCT_TYPE { get; set; }
            public string CONTROL_NO { get; set; }
            public string CONTRACT_NO { get; set; }
            public string STATUS { get; set; }
            public string STORAGE_PERIOD { get; set; }
            public string RESPONSE_DATE { get; set; }
            public string ESCALATION_RESPONSE { get; set; }
            public string TRACKING_NO { get; set; }
            public string SHIPPING_DATE { get; set; }
        }

        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB010(string userName)
        {
            _logger.Info("私物返却管理DB：検索 開始");

            _userName = userName;
            dao = new daofrmMSPB010("DBConnection", _userName);

            InitializeComponent();

            this.CmbProductType.Items.Add("プレドラ");
            this.CmbProductType.Items.Add("ドラレコ");
            this.CmbProductType.Items.Add("プレドラ切替");


            // ステータステーブルプルダウン
            setStatus();

            this.CmbReturnPlace.Items.Add("1 : 契約者返却");
            this.CmbReturnPlace.Items.Add("2 : MS返却");


            // エスカレ回答テーブルプルダウン
            setEscalationReponse();

            // 入力欄初期化
            inputMenuDefualtDisplay();

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
            dataGridView_Response_List_Binding();
        }

        #endregion

        #region イベント

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("検索：戻るボタン押下");
            this.Close();
        }
        #endregion

        #region 検索ボタン押下
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _logger.Debug("検索：検索ボタン押下");
            _logger.Info("検索 : 開始");

            btnTempResponseFindClick(sender, e);

        }
        #endregion

        #endregion


        #region メソッド

        #region 入力項目初期化
        private void inputMenuDefualtDisplay()
        {
        }
        #endregion

        #region ステータステーブルプルダウン設定
        private void setStatus()
        {
            try
            {
                // ステータステーブルから入力した管理番号存在チェック
                dtStatus = dao.Select_T_STATUS();


                _logger.Info("ステータステーブル取得数 [" + dtStatus.Rows.Count + "]");

                if (dtStatus.Rows.Count <= 0)
                {
                    _logger.Info("ステータステーブルに該当データが存在しません。");
                }
                else
                {
                    CmbStatus.DataSource = dtStatus;
                    CmbStatus.DisplayMember = "STATUS_TEXT";
                    CmbStatus.ValueMember = "STATUS_CODE";
                }
            }
            catch (Exception ex)
            {
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
        }


        #region エスカレ回答テーブルプルダウン設定
        private void setEscalationReponse()
        {
            try
            {
                // エスカレ回答テーブルから入力した管理番号存在チェック
                dtStatus = dao.Select_T_ESCALATION_RESPONSE();

                _logger.Info("エスカレ回答テーブル取得数 [" + dtStatus.Rows.Count + "]");

                if (dtStatus.Rows.Count <= 0)
                {
                    _logger.Info("エスカレ回答テーブルに該当データが存在しません。");
                    new clsMessageBox().MessageBoxOKOnly("例外が発生しました。詳細はログを参照ください", "エラー", MessageBoxIcon.Error);
                }
                else
                {
                    CmbEscalationResponse.DataSource = dtStatus;
                    CmbEscalationResponse.DisplayMember = "RESPONSE_TEXT";
                    CmbEscalationResponse.ValueMember = "RESPONSE_CODE";
                }
            }
            catch (Exception ex)
            {
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #endregion

        private void btnTempResponseFindClick(object sender, EventArgs e)
        {
            try
            {
                dataGridView_Response_List_Binding();
            }
            catch (Exception ex)
            {
                _logger.Error("★★★エスカレテーブルの検索でエラーが発生しました。", ex);
                new clsMessageBox().MessageBoxOKOnly("例外が発生しました。詳細はログを参照ください" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
            }
        }

        #region エスカレ回答検索結果一覧Gridviewバインド        
        private void dataGridView_Response_List_Binding()
        {
            try
            {
                using (var dao = new dao.daofrmMSPB010("DBConnection", Environment.UserName))
                {
                    string strProductType = null;
                    string strStatus = null;
                    string strReturnPlace = null;
                    string strEscalationResponse = null;


                    if (!string.IsNullOrEmpty(CmbProductType.Text))
                    {
                        strProductType = CmbProductType.Text;
                    }

                    if (!string.IsNullOrEmpty(CmbStatus.Text))
                    {
                        strStatus = CmbStatus.Text;
                    }

                    if (!string.IsNullOrEmpty(CmbReturnPlace.Text))
                    {
                        strReturnPlace = CmbReturnPlace.Text.Substring(0, 1);
                    }

                    if (!string.IsNullOrEmpty(CmbEscalationResponse.Text))
                    {
                        strEscalationResponse = CmbEscalationResponse.Text;
                    }
                    List<Escalation_Search_List> dtos = new List<Escalation_Search_List>();

                    DataTable dt = new DataTable();
                    dt.Clear();

                    dt = dao.Select_T_ESCALATION(
                        txtRegistDate.Text
                        , strProductType
                        , txtControlNo.Text
                        , txtContractNo.Text
                        , strStatus
                        , txtPersonalBelongingsInfo.Text
                        , txtReportDate.Text
                        , txtStorageReferenceDate.Text
                        , txtStoragePeriod.Text
                        , txtResponseDate.Text
                        , strReturnPlace
                        , strEscalationResponse
                        , txtTrackNo.Text
                        , txtShippingDate.Text);

                    this.lblCount.Text = dt.Rows.Count.ToString() + " 件";

                    if (dt.Rows.Count <= 0)
                    {
                        _logger.Info("発送QMSテーブルに対象データが存在しません。");

                        // 空のデータグリッドビューを表示する
                        // データグリッドビューのクリア
                        dataGridView_Search_List.DataSource = null;
                        // Packing_LineのリストをDataGridViewにデータバインドする
                        dataGridView_Search_List.DataSource = dtos;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Escalation_Search_List dto = new Escalation_Search_List();

                        string status_Work;
                        string escalation_Response;
                        string storage_Period;

                        switch (dt.Rows[i]["STATUS"].ToString())
                        {
                            case "0":
                                status_Work = "エスカレ";
                                break;
                            case "1":
                                status_Work = "エスカレ送付";
                                break;
                            case "2":
                                status_Work = "回答済";
                                break;
                            case "3":
                                status_Work = "承認";
                                break;
                            case "4":
                                status_Work = "承認保管期間経過";
                                break;
                            case "5":
                                status_Work = "返却処理";
                                break;
                            case "6":
                                status_Work = "返却済";
                                break;
                            case "9":
                                status_Work = "不着";
                                break;
                            default:
                                status_Work = null;
                                break;
                        }
                        

                        switch (dt.Rows[i]["ESCALATION_RESPONSE"].ToString())
                        {
                            case "0":
                                escalation_Response = "エスカレ";
                                break;
                            case "1":
                                escalation_Response = "契約者返却";
                                break;
                            case "2":
                                escalation_Response = "MS返却";
                                break;
                            case "3":
                                escalation_Response = "保管期間経過";
                                break;
                            default:
                                escalation_Response = null;
                                break;
                        }

                        if (string.IsNullOrEmpty(dt.Rows[i]["STORAGE_PERIOD"].ToString()))
                        {
                            storage_Period = dt.Rows[i]["STORAGE_PERIOD"].ToString();
                        }
                        else
                        {
                            storage_Period = DateTime.Parse(dt.Rows[i]["STORAGE_PERIOD"].ToString()).ToString("yyyyMMdd");
                        }

                        dto.REGIST_DATE = dt.Rows[i]["REGIST_DATE"].ToString();
                        dto.PRODUCT_TYPE = dt.Rows[i]["PRODUCT_TYPE"].ToString();
                        dto.CONTROL_NO = dt.Rows[i]["CONTROL_NO"].ToString();
                        dto.CONTRACT_NO = dt.Rows[i]["CONTRACT_NO"].ToString();
                        dto.STATUS = status_Work;
                        dto.STORAGE_PERIOD = storage_Period;
                        dto.RESPONSE_DATE = dt.Rows[i]["RESPONSE_DATE"].ToString();
                        dto.ESCALATION_RESPONSE = escalation_Response;
                        dto.TRACKING_NO = dt.Rows[i]["TRACKING_NO"].ToString();
                        dto.SHIPPING_DATE = dt.Rows[i]["SHIPPING_DATE"].ToString();

                        dtos.Add(dto);
                    }
                    // Packing_LineのリストをDataGridViewにデータバインドする
                    dataGridView_Search_List.DataSource = dtos;

                    // データグリッドのタイトル設定
                    dataGridView_Search_List.Columns[0].HeaderText = "登録日";
                    dataGridView_Search_List.Columns[1].HeaderText = "種別";
                    dataGridView_Search_List.Columns[2].HeaderText = "管理番号";
                    dataGridView_Search_List.Columns[3].HeaderText = "契約番号";
                    dataGridView_Search_List.Columns[4].HeaderText = "ステータス";
                    dataGridView_Search_List.Columns[5].HeaderText = "保管期限";
                    dataGridView_Search_List.Columns[6].HeaderText = "回答日";
                    dataGridView_Search_List.Columns[7].HeaderText = "エスカレ回答";
                    dataGridView_Search_List.Columns[8].HeaderText = "追跡番号";
                    dataGridView_Search_List.Columns[9].HeaderText = "出荷日";



                    // 更新禁止
                    dataGridView_Search_List.Columns[0].ReadOnly = true;
                    dataGridView_Search_List.Columns[1].ReadOnly = true;
                    dataGridView_Search_List.Columns[2].ReadOnly = true;
                    dataGridView_Search_List.Columns[3].ReadOnly = true;
                    dataGridView_Search_List.Columns[4].ReadOnly = true;
                    dataGridView_Search_List.Columns[5].ReadOnly = true;
                    dataGridView_Search_List.Columns[6].ReadOnly = true;
                    dataGridView_Search_List.Columns[7].ReadOnly = true;
                    dataGridView_Search_List.Columns[8].ReadOnly = true;
                    dataGridView_Search_List.Columns[9].ReadOnly = true;



                    // 初期表示の選択されているセルをなくす
                    dataGridView_Search_List.CurrentCell = null;

                    // ヘッダテキストの文字列の折り返しを抑止
                    dataGridView_Search_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                    // ヘッダテキストの文字配置はセル内センター
                    dataGridView_Search_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // 各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
                    foreach (DataGridViewColumn c in dataGridView_Search_List.Columns)
                        c.SortMode = DataGridViewColumnSortMode.NotSortable;

                    // 列の自動設定を抑止
                    dataGridView_Search_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // 各列の幅を設定
                    dataGridView_Search_List.Columns[0].Width = 75;
                    dataGridView_Search_List.Columns[1].Width = 82;
                    dataGridView_Search_List.Columns[2].Width = 158;
                    dataGridView_Search_List.Columns[3].Width = 175;
                    dataGridView_Search_List.Columns[4].Width = 90;
                    dataGridView_Search_List.Columns[5].Width = 75;
                    dataGridView_Search_List.Columns[6].Width = 75;
                    dataGridView_Search_List.Columns[7].Width = 95;
                    dataGridView_Search_List.Columns[8].Width = 110;
                    dataGridView_Search_List.Columns[9].Width = 75;

                    // 文字サイスを設定
                    dataGridView_Search_List.Font = new Font("メイリオ", 9);

                    // 列のセルのテキストの配置を上下左右とも中央にする
                    dataGridView_Search_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_Search_List.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



                    // 選択モードを行単位での選択のみにする
                    dataGridView_Search_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



                    // DataGridView1でセル、行、列が複数選択されないようにする
                    dataGridView_Search_List.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Info("エスカレテーブルのデータ取得でエラーが発生しました。" + ex.ToString());
                new clsMessageBox().MessageBoxOKOnly("エスカレテーブルのデータ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #endregion

        private void frmMSPB010_Load(object sender, EventArgs e)
        {
            // 初期値(未選択状態)
            CmbProductType.SelectedIndex = -1;
            CmbStatus.SelectedIndex = -1;
            CmbReturnPlace.SelectedIndex = -1;
            CmbEscalationResponse.SelectedIndex = -1;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    using (frmMSPB011 frmAppSearch = new frmMSPB011(_userName))
                    {
                        frmAppSearch.ControlNo = this.dataGridView_Search_List[2, e.RowIndex].Value.ToString();
                        _logger.Info("＞＞＞ 画面起動：MSPB010  管理番号 ＝ " + frmAppSearch.ControlNo + " ＜＜＜");
                        frmAppSearch.ShowDialog();

                        btnTempResponseFindClick(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("★★★例外発生:", ex);
                    new clsMessageBox().MessageBoxOKOnly("例外が発生しました。詳細はログを参照ください", "エラー", MessageBoxIcon.Error);
                }
            }
        }
    }
}
