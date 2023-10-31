using System;
using System.Windows.Forms;
using log4net;
using MSPB.Common;
using MSPB.MSPB010.dao;
using System.Data;

namespace MSPB.MSPB010.form
{

    /// <summary>
    /// 検索画面
    /// </summary>
    class frmMSPB011 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Button btnCancel;
        private TextBox txtContractorName;
        private Label lblContractorName;
        private TextBox txtContractNo;
        private Label lblContractNo;
        private TextBox txtControlNo;
        private Label lblControlNo;
        private TextBox txtProductType;
        private Label lblProductType;
        private Panel panel1;
        private TextBox txtStoragePeriod;
        private Label lblStoragePeriod;
        private TextBox txtStorageReferenceDate;
        private Label lblStorageReferenceDate;
        private TextBox txtRegistDate;
        private Label lblRegistDate;
        private TextBox txtStatus;
        private Label lblStatus;
        private TextBox txtSendDestTelNo;
        private Label lblSendDestTelNo;
        private TextBox txtSendDestName;
        private Label lblSendDestName;
        private TextBox txtSendDestAddress;
        private Label lblSendDestAddress;
        private TextBox txtSendDestPostalCode;
        private Label lblSendDestPostalCode;
        private TextBox txtPersonalBelogningsInfo;
        private Label lblPersonalBelogningsInfo;
        private TextBox txtResponseText;
        private Label label1;
        private TextBox txtReturnPlace;
        private Label lblReturnPlace;
        private TextBox txtReponseDate;
        private Label lblReponseDate;
        private TextBox txtReportDate;
        private Label lblReportDate;
        private ComboBox CmbNonArrivalReason;
        private Label lblNonArrivalReason;
        private TextBox txtNonArrivalDate;
        private Label lblNonArrivalDate;
        private TextBox txtApprovalName;
        private Label lblApprovalName;
        private TextBox txtResponseUserName;
        private Label lblResponseUserName;
        private TextBox txtRegistUserName;
        private Label lblRegistUserName;
        private TextBox txtTrackNo;
        private Label lblTrackNo;
        private TextBox txtShippingDate;
        private Label lblShippingDate;
        private Button btnNonArrival;
        private Button btnUpdate;
        private System.Windows.Forms.Label header0;


        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtContractorName = new System.Windows.Forms.TextBox();
            this.lblContractorName = new System.Windows.Forms.Label();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.lblContractNo = new System.Windows.Forms.Label();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.lblControlNo = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbNonArrivalReason = new System.Windows.Forms.ComboBox();
            this.lblNonArrivalReason = new System.Windows.Forms.Label();
            this.txtNonArrivalDate = new System.Windows.Forms.TextBox();
            this.lblNonArrivalDate = new System.Windows.Forms.Label();
            this.txtApprovalName = new System.Windows.Forms.TextBox();
            this.lblApprovalName = new System.Windows.Forms.Label();
            this.txtResponseUserName = new System.Windows.Forms.TextBox();
            this.lblResponseUserName = new System.Windows.Forms.Label();
            this.txtRegistUserName = new System.Windows.Forms.TextBox();
            this.lblRegistUserName = new System.Windows.Forms.Label();
            this.txtTrackNo = new System.Windows.Forms.TextBox();
            this.lblTrackNo = new System.Windows.Forms.Label();
            this.txtShippingDate = new System.Windows.Forms.TextBox();
            this.lblShippingDate = new System.Windows.Forms.Label();
            this.txtPersonalBelogningsInfo = new System.Windows.Forms.TextBox();
            this.lblPersonalBelogningsInfo = new System.Windows.Forms.Label();
            this.txtResponseText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReturnPlace = new System.Windows.Forms.TextBox();
            this.lblReturnPlace = new System.Windows.Forms.Label();
            this.txtReponseDate = new System.Windows.Forms.TextBox();
            this.lblReponseDate = new System.Windows.Forms.Label();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.txtStoragePeriod = new System.Windows.Forms.TextBox();
            this.lblStoragePeriod = new System.Windows.Forms.Label();
            this.txtStorageReferenceDate = new System.Windows.Forms.TextBox();
            this.lblStorageReferenceDate = new System.Windows.Forms.Label();
            this.txtRegistDate = new System.Windows.Forms.TextBox();
            this.lblRegistDate = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtSendDestTelNo = new System.Windows.Forms.TextBox();
            this.lblSendDestTelNo = new System.Windows.Forms.Label();
            this.txtSendDestName = new System.Windows.Forms.TextBox();
            this.lblSendDestName = new System.Windows.Forms.Label();
            this.txtSendDestAddress = new System.Windows.Forms.TextBox();
            this.lblSendDestAddress = new System.Windows.Forms.Label();
            this.txtSendDestPostalCode = new System.Windows.Forms.TextBox();
            this.lblSendDestPostalCode = new System.Windows.Forms.Label();
            this.btnNonArrival = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(801, 100);
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
            this.header0.Location = new System.Drawing.Point(265, 14);
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
            this.header1.Location = new System.Drawing.Point(338, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(111, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "詳細情報";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(108, 710);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // txtContractorName
            // 
            this.txtContractorName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtContractorName.Location = new System.Drawing.Point(128, 72);
            this.txtContractorName.Name = "txtContractorName";
            this.txtContractorName.ReadOnly = true;
            this.txtContractorName.Size = new System.Drawing.Size(635, 27);
            this.txtContractorName.TabIndex = 117;
            // 
            // lblContractorName
            // 
            this.lblContractorName.AutoSize = true;
            this.lblContractorName.BackColor = System.Drawing.SystemColors.Control;
            this.lblContractorName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractorName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContractorName.Location = new System.Drawing.Point(63, 75);
            this.lblContractorName.Name = "lblContractorName";
            this.lblContractorName.Size = new System.Drawing.Size(61, 20);
            this.lblContractorName.TabIndex = 116;
            this.lblContractorName.Text = "契約者名";
            this.lblContractorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContractNo
            // 
            this.txtContractNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtContractNo.Location = new System.Drawing.Point(128, 35);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.ReadOnly = true;
            this.txtContractNo.Size = new System.Drawing.Size(225, 27);
            this.txtContractNo.TabIndex = 101;
            // 
            // lblContractNo
            // 
            this.lblContractNo.AutoSize = true;
            this.lblContractNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblContractNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContractNo.Location = new System.Drawing.Point(63, 38);
            this.lblContractNo.Name = "lblContractNo";
            this.lblContractNo.Size = new System.Drawing.Size(61, 20);
            this.lblContractNo.TabIndex = 100;
            this.lblContractNo.Text = "証券番号";
            this.lblContractNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtControlNo
            // 
            this.txtControlNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtControlNo.Location = new System.Drawing.Point(128, 5);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.ReadOnly = true;
            this.txtControlNo.Size = new System.Drawing.Size(225, 27);
            this.txtControlNo.TabIndex = 95;
            // 
            // lblControlNo
            // 
            this.lblControlNo.AutoSize = true;
            this.lblControlNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblControlNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblControlNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblControlNo.Location = new System.Drawing.Point(63, 9);
            this.lblControlNo.Name = "lblControlNo";
            this.lblControlNo.Size = new System.Drawing.Size(61, 20);
            this.lblControlNo.TabIndex = 94;
            this.lblControlNo.Text = "管理番号";
            this.lblControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductType
            // 
            this.txtProductType.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtProductType.Location = new System.Drawing.Point(511, 5);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(94, 27);
            this.txtProductType.TabIndex = 187;
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.BackColor = System.Drawing.SystemColors.Control;
            this.lblProductType.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProductType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProductType.Location = new System.Drawing.Point(470, 9);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(35, 20);
            this.lblProductType.TabIndex = 186;
            this.lblProductType.Text = "種別";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbNonArrivalReason);
            this.panel1.Controls.Add(this.lblNonArrivalReason);
            this.panel1.Controls.Add(this.txtNonArrivalDate);
            this.panel1.Controls.Add(this.lblNonArrivalDate);
            this.panel1.Controls.Add(this.txtApprovalName);
            this.panel1.Controls.Add(this.lblApprovalName);
            this.panel1.Controls.Add(this.txtResponseUserName);
            this.panel1.Controls.Add(this.lblResponseUserName);
            this.panel1.Controls.Add(this.txtRegistUserName);
            this.panel1.Controls.Add(this.lblRegistUserName);
            this.panel1.Controls.Add(this.txtTrackNo);
            this.panel1.Controls.Add(this.lblTrackNo);
            this.panel1.Controls.Add(this.txtShippingDate);
            this.panel1.Controls.Add(this.lblShippingDate);
            this.panel1.Controls.Add(this.txtPersonalBelogningsInfo);
            this.panel1.Controls.Add(this.lblPersonalBelogningsInfo);
            this.panel1.Controls.Add(this.txtResponseText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtReturnPlace);
            this.panel1.Controls.Add(this.lblReturnPlace);
            this.panel1.Controls.Add(this.txtReponseDate);
            this.panel1.Controls.Add(this.lblReponseDate);
            this.panel1.Controls.Add(this.txtReportDate);
            this.panel1.Controls.Add(this.lblReportDate);
            this.panel1.Controls.Add(this.txtStoragePeriod);
            this.panel1.Controls.Add(this.lblStoragePeriod);
            this.panel1.Controls.Add(this.txtStorageReferenceDate);
            this.panel1.Controls.Add(this.lblStorageReferenceDate);
            this.panel1.Controls.Add(this.txtRegistDate);
            this.panel1.Controls.Add(this.lblRegistDate);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.txtSendDestTelNo);
            this.panel1.Controls.Add(this.lblSendDestTelNo);
            this.panel1.Controls.Add(this.txtSendDestName);
            this.panel1.Controls.Add(this.lblSendDestName);
            this.panel1.Controls.Add(this.txtSendDestAddress);
            this.panel1.Controls.Add(this.lblSendDestAddress);
            this.panel1.Controls.Add(this.txtSendDestPostalCode);
            this.panel1.Controls.Add(this.lblSendDestPostalCode);
            this.panel1.Controls.Add(this.txtProductType);
            this.panel1.Controls.Add(this.lblProductType);
            this.panel1.Controls.Add(this.txtContractorName);
            this.panel1.Controls.Add(this.lblContractorName);
            this.panel1.Controls.Add(this.txtContractNo);
            this.panel1.Controls.Add(this.lblContractNo);
            this.panel1.Controls.Add(this.txtControlNo);
            this.panel1.Controls.Add(this.lblControlNo);
            this.panel1.Location = new System.Drawing.Point(10, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 570);
            this.panel1.TabIndex = 188;
            // 
            // CmbNonArrivalReason
            // 
            this.CmbNonArrivalReason.Enabled = false;
            this.CmbNonArrivalReason.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbNonArrivalReason.Location = new System.Drawing.Point(365, 533);
            this.CmbNonArrivalReason.Name = "CmbNonArrivalReason";
            this.CmbNonArrivalReason.Size = new System.Drawing.Size(94, 28);
            this.CmbNonArrivalReason.TabIndex = 227;
            // 
            // lblNonArrivalReason
            // 
            this.lblNonArrivalReason.AutoSize = true;
            this.lblNonArrivalReason.BackColor = System.Drawing.SystemColors.Control;
            this.lblNonArrivalReason.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNonArrivalReason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNonArrivalReason.Location = new System.Drawing.Point(300, 536);
            this.lblNonArrivalReason.Name = "lblNonArrivalReason";
            this.lblNonArrivalReason.Size = new System.Drawing.Size(61, 20);
            this.lblNonArrivalReason.TabIndex = 226;
            this.lblNonArrivalReason.Text = "不着理由";
            this.lblNonArrivalReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNonArrivalDate
            // 
            this.txtNonArrivalDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNonArrivalDate.Location = new System.Drawing.Point(128, 534);
            this.txtNonArrivalDate.Name = "txtNonArrivalDate";
            this.txtNonArrivalDate.ReadOnly = true;
            this.txtNonArrivalDate.Size = new System.Drawing.Size(94, 27);
            this.txtNonArrivalDate.TabIndex = 225;
            // 
            // lblNonArrivalDate
            // 
            this.lblNonArrivalDate.AutoSize = true;
            this.lblNonArrivalDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblNonArrivalDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNonArrivalDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNonArrivalDate.Location = new System.Drawing.Point(77, 537);
            this.lblNonArrivalDate.Name = "lblNonArrivalDate";
            this.lblNonArrivalDate.Size = new System.Drawing.Size(48, 20);
            this.lblNonArrivalDate.TabIndex = 224;
            this.lblNonArrivalDate.Text = "不着日";
            this.lblNonArrivalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApprovalName
            // 
            this.txtApprovalName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtApprovalName.Location = new System.Drawing.Point(609, 499);
            this.txtApprovalName.Name = "txtApprovalName";
            this.txtApprovalName.ReadOnly = true;
            this.txtApprovalName.Size = new System.Drawing.Size(154, 27);
            this.txtApprovalName.TabIndex = 223;
            // 
            // lblApprovalName
            // 
            this.lblApprovalName.AutoSize = true;
            this.lblApprovalName.BackColor = System.Drawing.SystemColors.Control;
            this.lblApprovalName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblApprovalName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApprovalName.Location = new System.Drawing.Point(542, 502);
            this.lblApprovalName.Name = "lblApprovalName";
            this.lblApprovalName.Size = new System.Drawing.Size(61, 20);
            this.lblApprovalName.TabIndex = 222;
            this.lblApprovalName.Text = "承認者名";
            this.lblApprovalName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtResponseUserName
            // 
            this.txtResponseUserName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtResponseUserName.Location = new System.Drawing.Point(609, 469);
            this.txtResponseUserName.Name = "txtResponseUserName";
            this.txtResponseUserName.ReadOnly = true;
            this.txtResponseUserName.Size = new System.Drawing.Size(154, 27);
            this.txtResponseUserName.TabIndex = 221;
            // 
            // lblResponseUserName
            // 
            this.lblResponseUserName.AutoSize = true;
            this.lblResponseUserName.BackColor = System.Drawing.SystemColors.Control;
            this.lblResponseUserName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblResponseUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResponseUserName.Location = new System.Drawing.Point(516, 472);
            this.lblResponseUserName.Name = "lblResponseUserName";
            this.lblResponseUserName.Size = new System.Drawing.Size(87, 20);
            this.lblResponseUserName.TabIndex = 220;
            this.lblResponseUserName.Text = "回答担当者名";
            this.lblResponseUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRegistUserName
            // 
            this.txtRegistUserName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRegistUserName.Location = new System.Drawing.Point(609, 439);
            this.txtRegistUserName.Name = "txtRegistUserName";
            this.txtRegistUserName.ReadOnly = true;
            this.txtRegistUserName.Size = new System.Drawing.Size(154, 27);
            this.txtRegistUserName.TabIndex = 219;
            // 
            // lblRegistUserName
            // 
            this.lblRegistUserName.AutoSize = true;
            this.lblRegistUserName.BackColor = System.Drawing.SystemColors.Control;
            this.lblRegistUserName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistUserName.Location = new System.Drawing.Point(516, 442);
            this.lblRegistUserName.Name = "lblRegistUserName";
            this.lblRegistUserName.Size = new System.Drawing.Size(87, 20);
            this.lblRegistUserName.TabIndex = 218;
            this.lblRegistUserName.Text = "登録担当者名";
            this.lblRegistUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTrackNo
            // 
            this.txtTrackNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTrackNo.Location = new System.Drawing.Point(128, 468);
            this.txtTrackNo.Name = "txtTrackNo";
            this.txtTrackNo.ReadOnly = true;
            this.txtTrackNo.Size = new System.Drawing.Size(175, 27);
            this.txtTrackNo.TabIndex = 217;
            // 
            // lblTrackNo
            // 
            this.lblTrackNo.AutoSize = true;
            this.lblTrackNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTrackNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTrackNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrackNo.Location = new System.Drawing.Point(63, 471);
            this.lblTrackNo.Name = "lblTrackNo";
            this.lblTrackNo.Size = new System.Drawing.Size(61, 20);
            this.lblTrackNo.TabIndex = 216;
            this.lblTrackNo.Text = "追跡番号";
            this.lblTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShippingDate
            // 
            this.txtShippingDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtShippingDate.Location = new System.Drawing.Point(128, 438);
            this.txtShippingDate.Name = "txtShippingDate";
            this.txtShippingDate.ReadOnly = true;
            this.txtShippingDate.Size = new System.Drawing.Size(94, 27);
            this.txtShippingDate.TabIndex = 215;
            // 
            // lblShippingDate
            // 
            this.lblShippingDate.AutoSize = true;
            this.lblShippingDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblShippingDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShippingDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShippingDate.Location = new System.Drawing.Point(77, 443);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(48, 20);
            this.lblShippingDate.TabIndex = 214;
            this.lblShippingDate.Text = "出荷日";
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPersonalBelogningsInfo
            // 
            this.txtPersonalBelogningsInfo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPersonalBelogningsInfo.Location = new System.Drawing.Point(128, 382);
            this.txtPersonalBelogningsInfo.MaxLength = 100;
            this.txtPersonalBelogningsInfo.Multiline = true;
            this.txtPersonalBelogningsInfo.Name = "txtPersonalBelogningsInfo";
            this.txtPersonalBelogningsInfo.ReadOnly = true;
            this.txtPersonalBelogningsInfo.Size = new System.Drawing.Size(635, 44);
            this.txtPersonalBelogningsInfo.TabIndex = 213;
            // 
            // lblPersonalBelogningsInfo
            // 
            this.lblPersonalBelogningsInfo.AutoSize = true;
            this.lblPersonalBelogningsInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblPersonalBelogningsInfo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPersonalBelogningsInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonalBelogningsInfo.Location = new System.Drawing.Point(63, 385);
            this.lblPersonalBelogningsInfo.Name = "lblPersonalBelogningsInfo";
            this.lblPersonalBelogningsInfo.Size = new System.Drawing.Size(61, 20);
            this.lblPersonalBelogningsInfo.TabIndex = 212;
            this.lblPersonalBelogningsInfo.Text = "私物情報";
            this.lblPersonalBelogningsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtResponseText
            // 
            this.txtResponseText.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtResponseText.Location = new System.Drawing.Point(669, 351);
            this.txtResponseText.Name = "txtResponseText";
            this.txtResponseText.ReadOnly = true;
            this.txtResponseText.Size = new System.Drawing.Size(94, 27);
            this.txtResponseText.TabIndex = 211;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(578, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 210;
            this.label1.Text = "エスカレ回答";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReturnPlace
            // 
            this.txtReturnPlace.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtReturnPlace.Location = new System.Drawing.Point(394, 351);
            this.txtReturnPlace.Name = "txtReturnPlace";
            this.txtReturnPlace.ReadOnly = true;
            this.txtReturnPlace.Size = new System.Drawing.Size(94, 27);
            this.txtReturnPlace.TabIndex = 209;
            // 
            // lblReturnPlace
            // 
            this.lblReturnPlace.AutoSize = true;
            this.lblReturnPlace.BackColor = System.Drawing.SystemColors.Control;
            this.lblReturnPlace.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReturnPlace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReturnPlace.Location = new System.Drawing.Point(340, 354);
            this.lblReturnPlace.Name = "lblReturnPlace";
            this.lblReturnPlace.Size = new System.Drawing.Size(48, 20);
            this.lblReturnPlace.TabIndex = 208;
            this.lblReturnPlace.Text = "返却先";
            this.lblReturnPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReponseDate
            // 
            this.txtReponseDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtReponseDate.Location = new System.Drawing.Point(128, 351);
            this.txtReponseDate.Name = "txtReponseDate";
            this.txtReponseDate.ReadOnly = true;
            this.txtReponseDate.Size = new System.Drawing.Size(94, 27);
            this.txtReponseDate.TabIndex = 207;
            // 
            // lblReponseDate
            // 
            this.lblReponseDate.AutoSize = true;
            this.lblReponseDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblReponseDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReponseDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReponseDate.Location = new System.Drawing.Point(77, 354);
            this.lblReponseDate.Name = "lblReponseDate";
            this.lblReponseDate.Size = new System.Drawing.Size(48, 20);
            this.lblReponseDate.TabIndex = 206;
            this.lblReponseDate.Text = "回答日";
            this.lblReponseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReportDate
            // 
            this.txtReportDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtReportDate.Location = new System.Drawing.Point(128, 321);
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.ReadOnly = true;
            this.txtReportDate.Size = new System.Drawing.Size(94, 27);
            this.txtReportDate.TabIndex = 205;
            // 
            // lblReportDate
            // 
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblReportDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReportDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReportDate.Location = new System.Drawing.Point(77, 324);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(48, 20);
            this.lblReportDate.TabIndex = 204;
            this.lblReportDate.Text = "報告日";
            this.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStoragePeriod
            // 
            this.txtStoragePeriod.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStoragePeriod.Location = new System.Drawing.Point(669, 291);
            this.txtStoragePeriod.Name = "txtStoragePeriod";
            this.txtStoragePeriod.ReadOnly = true;
            this.txtStoragePeriod.Size = new System.Drawing.Size(94, 27);
            this.txtStoragePeriod.TabIndex = 203;
            // 
            // lblStoragePeriod
            // 
            this.lblStoragePeriod.AutoSize = true;
            this.lblStoragePeriod.BackColor = System.Drawing.SystemColors.Control;
            this.lblStoragePeriod.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStoragePeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoragePeriod.Location = new System.Drawing.Point(604, 294);
            this.lblStoragePeriod.Name = "lblStoragePeriod";
            this.lblStoragePeriod.Size = new System.Drawing.Size(61, 20);
            this.lblStoragePeriod.TabIndex = 202;
            this.lblStoragePeriod.Text = "保管期限";
            this.lblStoragePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStorageReferenceDate
            // 
            this.txtStorageReferenceDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStorageReferenceDate.Location = new System.Drawing.Point(394, 291);
            this.txtStorageReferenceDate.Name = "txtStorageReferenceDate";
            this.txtStorageReferenceDate.ReadOnly = true;
            this.txtStorageReferenceDate.Size = new System.Drawing.Size(94, 27);
            this.txtStorageReferenceDate.TabIndex = 201;
            // 
            // lblStorageReferenceDate
            // 
            this.lblStorageReferenceDate.AutoSize = true;
            this.lblStorageReferenceDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblStorageReferenceDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStorageReferenceDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStorageReferenceDate.Location = new System.Drawing.Point(315, 294);
            this.lblStorageReferenceDate.Name = "lblStorageReferenceDate";
            this.lblStorageReferenceDate.Size = new System.Drawing.Size(74, 20);
            this.lblStorageReferenceDate.TabIndex = 200;
            this.lblStorageReferenceDate.Text = "保管基準日";
            this.lblStorageReferenceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRegistDate
            // 
            this.txtRegistDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRegistDate.Location = new System.Drawing.Point(128, 291);
            this.txtRegistDate.Name = "txtRegistDate";
            this.txtRegistDate.ReadOnly = true;
            this.txtRegistDate.Size = new System.Drawing.Size(94, 27);
            this.txtRegistDate.TabIndex = 199;
            // 
            // lblRegistDate
            // 
            this.lblRegistDate.AutoSize = true;
            this.lblRegistDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblRegistDate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistDate.Location = new System.Drawing.Point(77, 294);
            this.lblRegistDate.Name = "lblRegistDate";
            this.lblRegistDate.Size = new System.Drawing.Size(48, 20);
            this.lblRegistDate.TabIndex = 198;
            this.lblRegistDate.Text = "登録日";
            this.lblRegistDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStatus.Location = new System.Drawing.Point(128, 253);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(154, 27);
            this.txtStatus.TabIndex = 197;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Location = new System.Drawing.Point(49, 256);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 20);
            this.lblStatus.TabIndex = 196;
            this.lblStatus.Text = "ステータス";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSendDestTelNo
            // 
            this.txtSendDestTelNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendDestTelNo.Location = new System.Drawing.Point(128, 215);
            this.txtSendDestTelNo.Name = "txtSendDestTelNo";
            this.txtSendDestTelNo.ReadOnly = true;
            this.txtSendDestTelNo.Size = new System.Drawing.Size(154, 27);
            this.txtSendDestTelNo.TabIndex = 195;
            // 
            // lblSendDestTelNo
            // 
            this.lblSendDestTelNo.AutoSize = true;
            this.lblSendDestTelNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblSendDestTelNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSendDestTelNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSendDestTelNo.Location = new System.Drawing.Point(21, 218);
            this.lblSendDestTelNo.Name = "lblSendDestTelNo";
            this.lblSendDestTelNo.Size = new System.Drawing.Size(100, 20);
            this.lblSendDestTelNo.TabIndex = 194;
            this.lblSendDestTelNo.Text = "発送先電話番号";
            this.lblSendDestTelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSendDestName
            // 
            this.txtSendDestName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendDestName.Location = new System.Drawing.Point(128, 185);
            this.txtSendDestName.Name = "txtSendDestName";
            this.txtSendDestName.ReadOnly = true;
            this.txtSendDestName.Size = new System.Drawing.Size(635, 27);
            this.txtSendDestName.TabIndex = 193;
            // 
            // lblSendDestName
            // 
            this.lblSendDestName.AutoSize = true;
            this.lblSendDestName.BackColor = System.Drawing.SystemColors.Control;
            this.lblSendDestName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSendDestName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSendDestName.Location = new System.Drawing.Point(63, 188);
            this.lblSendDestName.Name = "lblSendDestName";
            this.lblSendDestName.Size = new System.Drawing.Size(61, 20);
            this.lblSendDestName.TabIndex = 192;
            this.lblSendDestName.Text = "発送先名";
            this.lblSendDestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSendDestAddress
            // 
            this.txtSendDestAddress.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendDestAddress.Location = new System.Drawing.Point(128, 139);
            this.txtSendDestAddress.Multiline = true;
            this.txtSendDestAddress.Name = "txtSendDestAddress";
            this.txtSendDestAddress.ReadOnly = true;
            this.txtSendDestAddress.Size = new System.Drawing.Size(635, 43);
            this.txtSendDestAddress.TabIndex = 191;
            // 
            // lblSendDestAddress
            // 
            this.lblSendDestAddress.AutoSize = true;
            this.lblSendDestAddress.BackColor = System.Drawing.SystemColors.Control;
            this.lblSendDestAddress.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSendDestAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSendDestAddress.Location = new System.Drawing.Point(49, 142);
            this.lblSendDestAddress.Name = "lblSendDestAddress";
            this.lblSendDestAddress.Size = new System.Drawing.Size(74, 20);
            this.lblSendDestAddress.TabIndex = 190;
            this.lblSendDestAddress.Text = "発送先住所";
            this.lblSendDestAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSendDestPostalCode
            // 
            this.txtSendDestPostalCode.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendDestPostalCode.Location = new System.Drawing.Point(128, 109);
            this.txtSendDestPostalCode.Name = "txtSendDestPostalCode";
            this.txtSendDestPostalCode.ReadOnly = true;
            this.txtSendDestPostalCode.Size = new System.Drawing.Size(69, 27);
            this.txtSendDestPostalCode.TabIndex = 189;
            // 
            // lblSendDestPostalCode
            // 
            this.lblSendDestPostalCode.AutoSize = true;
            this.lblSendDestPostalCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblSendDestPostalCode.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSendDestPostalCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSendDestPostalCode.Location = new System.Drawing.Point(21, 112);
            this.lblSendDestPostalCode.Name = "lblSendDestPostalCode";
            this.lblSendDestPostalCode.Size = new System.Drawing.Size(100, 20);
            this.lblSendDestPostalCode.TabIndex = 188;
            this.lblSendDestPostalCode.Text = "発送先郵便番号";
            this.lblSendDestPostalCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNonArrival
            // 
            this.btnNonArrival.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNonArrival.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNonArrival.Location = new System.Drawing.Point(359, 710);
            this.btnNonArrival.Name = "btnNonArrival";
            this.btnNonArrival.Size = new System.Drawing.Size(110, 31);
            this.btnNonArrival.TabIndex = 189;
            this.btnNonArrival.Text = "不着";
            this.btnNonArrival.UseVisualStyleBackColor = true;
            this.btnNonArrival.Click += new System.EventHandler(this.btnNonArrival_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(593, 710);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 31);
            this.btnUpdate.TabIndex = 190;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmMSPB011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(819, 778);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNonArrival);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB011";
            this.Text = "MS 私物返却管理DB 詳細情報（検索）";
            this.Load += new System.EventHandler(this.frmMSPB011_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        ///
        private static string _userName;
        daofrmMSPB010 dao = null;
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string ControlNo { get; set; } // 管理番号
        string nonArrivalDate = null;
        string nonArrivalReason = null;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB011(string userName)
        {
            _userName = userName;
            dao = new daofrmMSPB010("DBConnection", _userName);

            InitializeComponent();

            this.CmbNonArrivalReason.Items.Add("長期不在");
            this.CmbNonArrivalReason.Items.Add("住所不明");
            this.CmbNonArrivalReason.Items.Add("その他");

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            this.ActiveControl = this.btnUpdate;

        }
        #endregion
        #region イベント
        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("詳細情報（検索）：戻るボタン押下");
            this.Close();
        }
        #endregion
        private void frmMSPB011_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dao = new daofrmMSPB010("DBConnection", _userName))
                {
                    string storage_Referemce_Date = null;
                    string storage_Period = null;
                    DataTable dt = dao.Select_T_ESCALATION(ControlNo);

                    if (dt.Rows.Count > 0)
                    {
                        //管理番号　　　　CONTROL_NO　　　　　　　　　this.txtControlNo
                        this.txtControlNo.Text = ControlNo;

                        //契約番号　　　　CONTRACT_NO　　　　　　　　this.txtContractNo
                        this.txtContractNo.Text = dt.Rows[0]["CONTRACT_NO"].ToString();

                        //契約者名　　　　CONTRACTOR_NAME　　　　　　this.txtContractorName
                        this.txtContractorName.Text = dt.Rows[0]["CONTRACTOR_NAME"].ToString();

                        //発送先郵便番号　SEND_DEST_POSTAL_CODE　　　this.txtSendDestPostalCode
                        this.txtSendDestPostalCode.Text = dt.Rows[0]["SEND_DEST_POSTAL_CODE"].ToString();

                        //発送先住所　　　SEND_DEST_ADDRESS　　　　　this.txtSendDestAddress
                        this.txtSendDestAddress.Text = dt.Rows[0]["SEND_DEST_ADDRESS"].ToString();

                        //発送先名　　　　SEND_DEST_NAME　　　　　　　this.txtSendDestName
                        this.txtSendDestName.Text = dt.Rows[0]["SEND_DEST_NAME"].ToString();

                        //発送先電話番号　SEND_DEST_TEL_NO　　　　　　this.txtSendDestTelNo
                        this.txtSendDestTelNo.Text = dt.Rows[0]["SEND_DEST_TEL_NO"].ToString();

                        //種別　　　　　　PRODUCT_TYPE　　　　　　　　this.txtProductType
                        this.txtProductType.Text = dt.Rows[0]["PRODUCT_TYPE"].ToString();

                        //ステータス　　　STATUSE_TEXT　　　　　　　　this.txtStatus
                        this.txtStatus.Text = dt.Rows[0]["STATUS_TEXT"].ToString();

                        //登録日　　　　　REGIST_DATE　　　　　　　　this.txtRegistDate
                        this.txtRegistDate.Text = dt.Rows[0]["REGIST_DATE"].ToString();

                        //報告日　　　　　REPORT_DATE　　　　　　　　this.txtReportDate
                        this.txtReportDate.Text = dt.Rows[0]["REPORT_DATE"].ToString();

                        //保管基準日　　　STORAGE_REFERENCE_DATE　　　this.txtStorageReferenceDate
                        if (! string.IsNullOrEmpty(dt.Rows[0]["STORAGE_REFERENCE_DATE"].ToString()))
                            storage_Referemce_Date = DateTime.Parse(dt.Rows[0]["STORAGE_REFERENCE_DATE"].ToString()).ToString("yyyyMMdd");

                        this.txtStorageReferenceDate.Text = storage_Referemce_Date;

                        //返却先　　　　　RETURN_PLACE　　　　　　　　this.txtReturnPlace
                        this.txtReturnPlace.Text = dt.Rows[0]["RETURN_PLACE"].ToString();

                        //保管期限　　　　STORAGE_PERIODE　　　　　　this.txtStoragePeriod
                        this.txtStoragePeriod.Text = dt.Rows[0]["STORAGE_PERIOD"].ToString();

                        if (! string.IsNullOrEmpty(dt.Rows[0]["STORAGE_PERIOD"].ToString()))
                            storage_Period = DateTime.Parse(dt.Rows[0]["STORAGE_PERIOD"].ToString()).ToString("yyyyMMdd");

                        this.txtStoragePeriod.Text = storage_Period;

                        //回答日　　　　　RESPONSE_DATE　　　　　　　this.txtReponseDate
                        this.txtReponseDate.Text = dt.Rows[0]["RESPONSE_DATE"].ToString();

                        //私物情報　　　　PERSONAL_BELONGINGS_INFO　　this.txtPersonalBelogningsInfo
                        this.txtPersonalBelogningsInfo.Text = dt.Rows[0]["PERSONAL_BELONGINGS_INFO"].ToString();

                        //出荷日　　　　　SHIPPING_DATE　　　　　　　this.txtShippingDate
                        this.txtShippingDate.Text = dt.Rows[0]["SHIPPING_DATE"].ToString();

                        //追跡番号　　　　TRACKING_NO　　　　　　　　this.txtTrackNo
                        this.txtTrackNo.Text = dt.Rows[0]["TRACKING_NO"].ToString();

                        //エスカレ回答　　RESPONSE_TEXT　　　　　　　this.txtResponseText
                        this.txtResponseText.Text = dt.Rows[0]["RESPONSE_TEXT"].ToString();

                        //登録担当者名　　REGIST_USER_NAME　　　　　　this.txtRegistUserName
                        this.txtRegistUserName.Text = dt.Rows[0]["REGIST_USER_NAME"].ToString();

                        //回答担当者名　　RESPONSE_USER_NAME　　　　　this.txtResponseUserName
                        this.txtResponseUserName.Text = dt.Rows[0]["RESPONSE_USER_NAME"].ToString();

                        //承認者名　　　　APPROVER_NAME　　　　　　　this.txtApprovalName
                        this.txtApprovalName.Text = dt.Rows[0]["APPROVER_NAME"].ToString();

                        //不着日          NON_ARRIVAL_DATE           this.txtNonArrivalDate
                        this.txtNonArrivalDate.Text = dt.Rows[0]["NON_ARRIVAL_DATE"].ToString();

                        //不着理由        NON_ARRIVAL_REASON         this.CmbNonArrivalReason
                        this.CmbNonArrivalReason.SelectedItem = dt.Rows[0]["NON_ARRIVAL_REASON"].ToString();
                    }
                    else
                    {
                        _logger.Error("対象の管理番号が見当たりません。");
                        new clsMessageBox().MessageBoxOKOnly("対象の管理番号が見当たりません", "エラー", MessageBoxIcon.Error);
                        this.Close();
                    }
                    dt.Clear();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("出荷依頼テーブルの検索でエラーが発生しました。", ex);
                new clsMessageBox().MessageBoxOKOnly("例外が発生しました。詳細はログを参照ください", "エラー", MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion

        private void btnNonArrival_Click(object sender, EventArgs e)
        {
            //不着日と不着理由欄と更新ボタンを活性化
            this.txtNonArrivalDate.ReadOnly = false;
            this.CmbNonArrivalReason.Enabled = true;
            this.btnUpdate.Enabled = true;

            // 不着日がNullの場合、システム日付セット
            if (string.IsNullOrEmpty(this.txtNonArrivalDate.Text))
            {
                this.txtNonArrivalDate.Text = DateTime.Now.ToString("yyyyMMdd");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            nonArrivalDate = this.txtNonArrivalDate.Text;

            if (this.CmbNonArrivalReason.SelectedItem == null)
            {
                new clsMessageBox().MessageBoxOKOnly("不着理由が未選択です。" + Environment.NewLine + "不着理由を選択してください。", "エラー", MessageBoxIcon.Error);
                this.CmbNonArrivalReason.Focus();
                return;
            }

            nonArrivalReason = this.CmbNonArrivalReason.SelectedItem.ToString();

            //エスカレテーブルに概要データ更新
            using (var dao = new dao.daofrmMSPB010("DBConnection", Environment.UserName))
            {
                dao.Update_T_ESCALATION(ControlNo, nonArrivalDate, nonArrivalReason);

                new clsMessageBox().MessageBoxOKOnly("更新完了しました", "確認", MessageBoxIcon.Information);

                frmMSPB011_Load(sender, e);
            }
        }
    }
}
