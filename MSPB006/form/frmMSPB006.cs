using System;
using System.Windows.Forms;
using log4net;
using MSPB.Common;
using MSPB.MSPB006.dao;
using System.Globalization;
using System.Data;

namespace MSPB.MSPB006.form
{
    
    /// <summary>
    /// 集計画面
    /// </summary>
    class frmMSPB006 : Form
    {
        #region デザイン
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
                
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Button btnCalcSum;
        private System.Windows.Forms.Label lblComment2;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.Label lblComment1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn escRegistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn escSendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalTimeOverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retrunProcessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noneArrivedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn escProcessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractorRtnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msRtnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msRtnTimeOverDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource T_ESCALATION_BindingSource;
        private System.Windows.Forms.Label txtMSRtnTimeOverSum;
        private System.Windows.Forms.Label txtMSRtnSum;
        private System.Windows.Forms.Label txtContractorRtnSum;
        private System.Windows.Forms.Label txtEscProcessSum;
        private System.Windows.Forms.Label txtNoneArrivedSum;
        private System.Windows.Forms.Label txtReturnedSum;
        private System.Windows.Forms.Label txtRetrunProcessSum;
        private System.Windows.Forms.Label txtApprovalTimeOverSum;
        private System.Windows.Forms.Label txtApprovalSum;
        private System.Windows.Forms.Label txtResponsedSum;
        private System.Windows.Forms.Label txtEscSendSum;
        private System.Windows.Forms.Label txtEscRegistSum;
        private System.Windows.Forms.Label txtSumValue;
        private System.Windows.Forms.Label txtHeader18;
        private System.Windows.Forms.Label txtHeader17;
        private System.Windows.Forms.Label txtHeader16;
        private System.Windows.Forms.Label txtHeader15;
        private System.Windows.Forms.Label txtHeader14;
        private System.Windows.Forms.Label txtHeader13;
        private System.Windows.Forms.Label txtHeader12;
        private System.Windows.Forms.Label txtHeader11;
        private System.Windows.Forms.Label txtHeader10;
        private System.Windows.Forms.Label txtHeader9;
        private System.Windows.Forms.Label txtHeader8;
        private System.Windows.Forms.Label txtHeader7;
        private System.Windows.Forms.Label txtHeader6;
        private System.Windows.Forms.Label txtHeader5;
        private System.Windows.Forms.Label txtHeader4;
        private System.Windows.Forms.Label txtHeader3;
        private System.Windows.Forms.Label txtHeader2;
        private System.Windows.Forms.Label txtHeader1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
        

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.btnCalcSum = new System.Windows.Forms.Button();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escRegistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escSendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalTimeOverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retrunProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noneArrivedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractorRtnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msRtnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msRtnTimeOverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_ESCALATION_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtMSRtnTimeOverSum = new System.Windows.Forms.Label();
            this.txtMSRtnSum = new System.Windows.Forms.Label();
            this.txtContractorRtnSum = new System.Windows.Forms.Label();
            this.txtEscProcessSum = new System.Windows.Forms.Label();
            this.txtNoneArrivedSum = new System.Windows.Forms.Label();
            this.txtReturnedSum = new System.Windows.Forms.Label();
            this.txtRetrunProcessSum = new System.Windows.Forms.Label();
            this.txtApprovalTimeOverSum = new System.Windows.Forms.Label();
            this.txtApprovalSum = new System.Windows.Forms.Label();
            this.txtResponsedSum = new System.Windows.Forms.Label();
            this.txtEscSendSum = new System.Windows.Forms.Label();
            this.txtEscRegistSum = new System.Windows.Forms.Label();
            this.txtSumValue = new System.Windows.Forms.Label();
            this.txtHeader18 = new System.Windows.Forms.Label();
            this.txtHeader17 = new System.Windows.Forms.Label();
            this.txtHeader16 = new System.Windows.Forms.Label();
            this.txtHeader15 = new System.Windows.Forms.Label();
            this.txtHeader14 = new System.Windows.Forms.Label();
            this.txtHeader13 = new System.Windows.Forms.Label();
            this.txtHeader12 = new System.Windows.Forms.Label();
            this.txtHeader11 = new System.Windows.Forms.Label();
            this.txtHeader10 = new System.Windows.Forms.Label();
            this.txtHeader9 = new System.Windows.Forms.Label();
            this.txtHeader8 = new System.Windows.Forms.Label();
            this.txtHeader7 = new System.Windows.Forms.Label();
            this.txtHeader6 = new System.Windows.Forms.Label();
            this.txtHeader5 = new System.Windows.Forms.Label();
            this.txtHeader4 = new System.Windows.Forms.Label();
            this.txtHeader3 = new System.Windows.Forms.Label();
            this.txtHeader2 = new System.Windows.Forms.Label();
            this.txtHeader1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ESCALATION_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1006, 100);
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
            this.header0.Location = new System.Drawing.Point(369, 14);
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
            this.header1.Location = new System.Drawing.Point(467, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(63, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "集計";
            // 
            // btnCalcSum
            // 
            this.btnCalcSum.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCalcSum.ForeColor = System.Drawing.Color.Black;
            this.btnCalcSum.Location = new System.Drawing.Point(785, 149);
            this.btnCalcSum.Name = "btnCalcSum";
            this.btnCalcSum.Size = new System.Drawing.Size(110, 31);
            this.btnCalcSum.TabIndex = 13;
            this.btnCalcSum.Text = "集計";
            this.btnCalcSum.UseVisualStyleBackColor = true;
            this.btnCalcSum.Click += new System.EventHandler(this.Btn_CalcSum_Click);
            // 
            // lblComment2
            // 
            this.lblComment2.AutoSize = true;
            this.lblComment2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment2.Location = new System.Drawing.Point(352, 153);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(150, 24);
            this.lblComment2.TabIndex = 12;
            this.lblComment2.Text = "（yyyy-mm-dd）";
            // 
            // txtDateTo
            // 
            this.txtDateTo.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateTo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDateTo.Location = new System.Drawing.Point(204, 150);
            this.txtDateTo.MaxLength = 10;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(121, 27);
            this.txtDateTo.TabIndex = 11;
            this.txtDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Date_KeyPress);
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLine.Location = new System.Drawing.Point(162, 164);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(42, 1);
            this.lblLine.TabIndex = 10;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDateFrom.Location = new System.Drawing.Point(41, 150);
            this.txtDateFrom.MaxLength = 10;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(121, 27);
            this.txtDateFrom.TabIndex = 9;
            this.txtDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Date_KeyPress);
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment1.Location = new System.Drawing.Point(40, 125);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(74, 24);
            this.lblComment1.TabIndex = 8;
            this.lblComment1.Text = "期間集計";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.registDateDataGridViewTextBoxColumn,
            this.sumValueDataGridViewTextBoxColumn,
            this.escRegistDataGridViewTextBoxColumn,
            this.escSendDataGridViewTextBoxColumn,
            this.responsedDataGridViewTextBoxColumn,
            this.approvalDataGridViewTextBoxColumn,
            this.approvalTimeOverDataGridViewTextBoxColumn,
            this.retrunProcessDataGridViewTextBoxColumn,
            this.returnedDataGridViewTextBoxColumn,
            this.noneArrivedDataGridViewTextBoxColumn,
            this.escProcessDataGridViewTextBoxColumn,
            this.contractorRtnDataGridViewTextBoxColumn,
            this.msRtnDataGridViewTextBoxColumn,
            this.msRtnTimeOverDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.T_ESCALATION_BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 265);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1001, 225);
            this.dataGridView1.TabIndex = 91;
            this.dataGridView1.TabStop = false;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 32;
            // 
            // registDateDataGridViewTextBoxColumn
            // 
            this.registDateDataGridViewTextBoxColumn.DataPropertyName = "RegistDate";
            this.registDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.registDateDataGridViewTextBoxColumn.HeaderText = "RegistDate";
            this.registDateDataGridViewTextBoxColumn.Name = "registDateDataGridViewTextBoxColumn";
            this.registDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.registDateDataGridViewTextBoxColumn.Width = 71;
            // 
            // sumValueDataGridViewTextBoxColumn
            // 
            this.sumValueDataGridViewTextBoxColumn.DataPropertyName = "SumValue";
            this.sumValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sumValueDataGridViewTextBoxColumn.HeaderText = "SumValue";
            this.sumValueDataGridViewTextBoxColumn.Name = "sumValueDataGridViewTextBoxColumn";
            this.sumValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumValueDataGridViewTextBoxColumn.Width = 53;
            // 
            // escRegistDataGridViewTextBoxColumn
            // 
            this.escRegistDataGridViewTextBoxColumn.DataPropertyName = "EscRegist";
            this.escRegistDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.escRegistDataGridViewTextBoxColumn.HeaderText = "EscRegist";
            this.escRegistDataGridViewTextBoxColumn.Name = "escRegistDataGridViewTextBoxColumn";
            this.escRegistDataGridViewTextBoxColumn.ReadOnly = true;
            this.escRegistDataGridViewTextBoxColumn.Width = 69;
            // 
            // escSendDataGridViewTextBoxColumn
            // 
            this.escSendDataGridViewTextBoxColumn.DataPropertyName = "EscSend";
            this.escSendDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.escSendDataGridViewTextBoxColumn.HeaderText = "EscSend";
            this.escSendDataGridViewTextBoxColumn.Name = "escSendDataGridViewTextBoxColumn";
            this.escSendDataGridViewTextBoxColumn.ReadOnly = true;
            this.escSendDataGridViewTextBoxColumn.Width = 69;
            // 
            // responsedDataGridViewTextBoxColumn
            // 
            this.responsedDataGridViewTextBoxColumn.DataPropertyName = "Responsed";
            this.responsedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.responsedDataGridViewTextBoxColumn.HeaderText = "Responsed";
            this.responsedDataGridViewTextBoxColumn.Name = "responsedDataGridViewTextBoxColumn";
            this.responsedDataGridViewTextBoxColumn.ReadOnly = true;
            this.responsedDataGridViewTextBoxColumn.Width = 69;
            // 
            // approvalDataGridViewTextBoxColumn
            // 
            this.approvalDataGridViewTextBoxColumn.DataPropertyName = "Approval";
            this.approvalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.approvalDataGridViewTextBoxColumn.HeaderText = "Approval";
            this.approvalDataGridViewTextBoxColumn.Name = "approvalDataGridViewTextBoxColumn";
            this.approvalDataGridViewTextBoxColumn.ReadOnly = true;
            this.approvalDataGridViewTextBoxColumn.Width = 69;
            // 
            // approvalTimeOverDataGridViewTextBoxColumn
            // 
            this.approvalTimeOverDataGridViewTextBoxColumn.DataPropertyName = "ApprovalTimeOver";
            this.approvalTimeOverDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.approvalTimeOverDataGridViewTextBoxColumn.HeaderText = "ApprovalTimeOver";
            this.approvalTimeOverDataGridViewTextBoxColumn.Name = "approvalTimeOverDataGridViewTextBoxColumn";
            this.approvalTimeOverDataGridViewTextBoxColumn.ReadOnly = true;
            this.approvalTimeOverDataGridViewTextBoxColumn.Width = 69;
            // 
            // retrunProcessDataGridViewTextBoxColumn
            // 
            this.retrunProcessDataGridViewTextBoxColumn.DataPropertyName = "RetrunProcess";
            this.retrunProcessDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.retrunProcessDataGridViewTextBoxColumn.HeaderText = "RetrunProcess";
            this.retrunProcessDataGridViewTextBoxColumn.Name = "retrunProcessDataGridViewTextBoxColumn";
            this.retrunProcessDataGridViewTextBoxColumn.ReadOnly = true;
            this.retrunProcessDataGridViewTextBoxColumn.Width = 69;
            // 
            // returnedDataGridViewTextBoxColumn
            // 
            this.returnedDataGridViewTextBoxColumn.DataPropertyName = "Returned";
            this.returnedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.returnedDataGridViewTextBoxColumn.HeaderText = "Returned";
            this.returnedDataGridViewTextBoxColumn.Name = "returnedDataGridViewTextBoxColumn";
            this.returnedDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnedDataGridViewTextBoxColumn.Width = 69;
            // 
            // noneArrivedDataGridViewTextBoxColumn
            // 
            this.noneArrivedDataGridViewTextBoxColumn.DataPropertyName = "NoneArrived";
            this.noneArrivedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.noneArrivedDataGridViewTextBoxColumn.HeaderText = "NoneArrived";
            this.noneArrivedDataGridViewTextBoxColumn.Name = "noneArrivedDataGridViewTextBoxColumn";
            this.noneArrivedDataGridViewTextBoxColumn.ReadOnly = true;
            this.noneArrivedDataGridViewTextBoxColumn.Width = 69;
            // 
            // escProcessDataGridViewTextBoxColumn
            // 
            this.escProcessDataGridViewTextBoxColumn.DataPropertyName = "EscProcess";
            this.escProcessDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.escProcessDataGridViewTextBoxColumn.HeaderText = "EscProcess";
            this.escProcessDataGridViewTextBoxColumn.Name = "escProcessDataGridViewTextBoxColumn";
            this.escProcessDataGridViewTextBoxColumn.ReadOnly = true;
            this.escProcessDataGridViewTextBoxColumn.Width = 69;
            // 
            // contractorRtnDataGridViewTextBoxColumn
            // 
            this.contractorRtnDataGridViewTextBoxColumn.DataPropertyName = "ContractorRtn";
            this.contractorRtnDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.contractorRtnDataGridViewTextBoxColumn.HeaderText = "ContractorRtn";
            this.contractorRtnDataGridViewTextBoxColumn.Name = "contractorRtnDataGridViewTextBoxColumn";
            this.contractorRtnDataGridViewTextBoxColumn.ReadOnly = true;
            this.contractorRtnDataGridViewTextBoxColumn.Width = 69;
            // 
            // msRtnDataGridViewTextBoxColumn
            // 
            this.msRtnDataGridViewTextBoxColumn.DataPropertyName = "MSRtn";
            this.msRtnDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.msRtnDataGridViewTextBoxColumn.HeaderText = "MSRtn";
            this.msRtnDataGridViewTextBoxColumn.Name = "msRtnDataGridViewTextBoxColumn";
            this.msRtnDataGridViewTextBoxColumn.ReadOnly = true;
            this.msRtnDataGridViewTextBoxColumn.Width = 69;
            // 
            // msRtnTimeOverDataGridViewTextBoxColumn
            // 
            this.msRtnTimeOverDataGridViewTextBoxColumn.DataPropertyName = "MSRtnTimeOver";
            this.msRtnTimeOverDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.msRtnTimeOverDataGridViewTextBoxColumn.HeaderText = "MSRtnTimeOver";
            this.msRtnTimeOverDataGridViewTextBoxColumn.Name = "msRtnTimeOverDataGridViewTextBoxColumn";
            this.msRtnTimeOverDataGridViewTextBoxColumn.ReadOnly = true;
            this.msRtnTimeOverDataGridViewTextBoxColumn.Width = 69;
            // 
            // T_ESCALATION_BindingSource
            // 
            this.T_ESCALATION_BindingSource.DataSource = typeof(MSPB.MSPB006.dao.daofrmMSPB006.TotalResult_T_ESCALATION);
            // 
            // txtMSRtnTimeOverSum
            // 
            this.txtMSRtnTimeOverSum.BackColor = System.Drawing.Color.LightGray;
            this.txtMSRtnTimeOverSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMSRtnTimeOverSum.Location = new System.Drawing.Point(930, 248);
            this.txtMSRtnTimeOverSum.Name = "txtMSRtnTimeOverSum";
            this.txtMSRtnTimeOverSum.Size = new System.Drawing.Size(70, 19);
            this.txtMSRtnTimeOverSum.TabIndex = 86;
            this.txtMSRtnTimeOverSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMSRtnSum
            // 
            this.txtMSRtnSum.BackColor = System.Drawing.Color.LightGray;
            this.txtMSRtnSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMSRtnSum.Location = new System.Drawing.Point(861, 248);
            this.txtMSRtnSum.Name = "txtMSRtnSum";
            this.txtMSRtnSum.Size = new System.Drawing.Size(70, 19);
            this.txtMSRtnSum.TabIndex = 85;
            this.txtMSRtnSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContractorRtnSum
            // 
            this.txtContractorRtnSum.BackColor = System.Drawing.Color.LightGray;
            this.txtContractorRtnSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtContractorRtnSum.Location = new System.Drawing.Point(792, 248);
            this.txtContractorRtnSum.Name = "txtContractorRtnSum";
            this.txtContractorRtnSum.Size = new System.Drawing.Size(70, 19);
            this.txtContractorRtnSum.TabIndex = 84;
            this.txtContractorRtnSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEscProcessSum
            // 
            this.txtEscProcessSum.BackColor = System.Drawing.Color.LightGray;
            this.txtEscProcessSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEscProcessSum.Location = new System.Drawing.Point(723, 248);
            this.txtEscProcessSum.Name = "txtEscProcessSum";
            this.txtEscProcessSum.Size = new System.Drawing.Size(70, 19);
            this.txtEscProcessSum.TabIndex = 83;
            this.txtEscProcessSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoneArrivedSum
            // 
            this.txtNoneArrivedSum.BackColor = System.Drawing.Color.LightGray;
            this.txtNoneArrivedSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNoneArrivedSum.Location = new System.Drawing.Point(654, 248);
            this.txtNoneArrivedSum.Name = "txtNoneArrivedSum";
            this.txtNoneArrivedSum.Size = new System.Drawing.Size(70, 19);
            this.txtNoneArrivedSum.TabIndex = 82;
            this.txtNoneArrivedSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReturnedSum
            // 
            this.txtReturnedSum.BackColor = System.Drawing.Color.LightGray;
            this.txtReturnedSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtReturnedSum.Location = new System.Drawing.Point(585, 248);
            this.txtReturnedSum.Name = "txtReturnedSum";
            this.txtReturnedSum.Size = new System.Drawing.Size(70, 19);
            this.txtReturnedSum.TabIndex = 81;
            this.txtReturnedSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRetrunProcessSum
            // 
            this.txtRetrunProcessSum.BackColor = System.Drawing.Color.LightGray;
            this.txtRetrunProcessSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtRetrunProcessSum.Location = new System.Drawing.Point(516, 248);
            this.txtRetrunProcessSum.Name = "txtRetrunProcessSum";
            this.txtRetrunProcessSum.Size = new System.Drawing.Size(70, 19);
            this.txtRetrunProcessSum.TabIndex = 80;
            this.txtRetrunProcessSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtApprovalTimeOverSum
            // 
            this.txtApprovalTimeOverSum.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovalTimeOverSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtApprovalTimeOverSum.Location = new System.Drawing.Point(447, 248);
            this.txtApprovalTimeOverSum.Name = "txtApprovalTimeOverSum";
            this.txtApprovalTimeOverSum.Size = new System.Drawing.Size(70, 19);
            this.txtApprovalTimeOverSum.TabIndex = 79;
            this.txtApprovalTimeOverSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtApprovalSum
            // 
            this.txtApprovalSum.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovalSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtApprovalSum.Location = new System.Drawing.Point(378, 248);
            this.txtApprovalSum.Name = "txtApprovalSum";
            this.txtApprovalSum.Size = new System.Drawing.Size(70, 19);
            this.txtApprovalSum.TabIndex = 78;
            this.txtApprovalSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtResponsedSum
            // 
            this.txtResponsedSum.BackColor = System.Drawing.Color.LightGray;
            this.txtResponsedSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtResponsedSum.Location = new System.Drawing.Point(309, 248);
            this.txtResponsedSum.Name = "txtResponsedSum";
            this.txtResponsedSum.Size = new System.Drawing.Size(70, 19);
            this.txtResponsedSum.TabIndex = 77;
            this.txtResponsedSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEscSendSum
            // 
            this.txtEscSendSum.BackColor = System.Drawing.Color.LightGray;
            this.txtEscSendSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEscSendSum.Location = new System.Drawing.Point(240, 248);
            this.txtEscSendSum.Name = "txtEscSendSum";
            this.txtEscSendSum.Size = new System.Drawing.Size(70, 19);
            this.txtEscSendSum.TabIndex = 76;
            this.txtEscSendSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEscRegistSum
            // 
            this.txtEscRegistSum.BackColor = System.Drawing.Color.LightGray;
            this.txtEscRegistSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEscRegistSum.Location = new System.Drawing.Point(171, 248);
            this.txtEscRegistSum.Name = "txtEscRegistSum";
            this.txtEscRegistSum.Size = new System.Drawing.Size(70, 19);
            this.txtEscRegistSum.TabIndex = 75;
            this.txtEscRegistSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSumValue
            // 
            this.txtSumValue.BackColor = System.Drawing.Color.LightGray;
            this.txtSumValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumValue.Location = new System.Drawing.Point(118, 248);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.Size = new System.Drawing.Size(54, 19);
            this.txtSumValue.TabIndex = 74;
            this.txtSumValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader18
            // 
            this.txtHeader18.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader18.Location = new System.Drawing.Point(47, 248);
            this.txtHeader18.Name = "txtHeader18";
            this.txtHeader18.Size = new System.Drawing.Size(72, 19);
            this.txtHeader18.TabIndex = 73;
            this.txtHeader18.Text = "登録日";
            this.txtHeader18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader17
            // 
            this.txtHeader17.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader17.Location = new System.Drawing.Point(15, 248);
            this.txtHeader17.Name = "txtHeader17";
            this.txtHeader17.Size = new System.Drawing.Size(33, 19);
            this.txtHeader17.TabIndex = 72;
            this.txtHeader17.Text = "NO";
            this.txtHeader17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader16
            // 
            this.txtHeader16.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader16.Location = new System.Drawing.Point(930, 216);
            this.txtHeader16.Name = "txtHeader16";
            this.txtHeader16.Size = new System.Drawing.Size(70, 33);
            this.txtHeader16.TabIndex = 67;
            this.txtHeader16.Text = "時間経過";
            this.txtHeader16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader15
            // 
            this.txtHeader15.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader15.Location = new System.Drawing.Point(861, 216);
            this.txtHeader15.Name = "txtHeader15";
            this.txtHeader15.Size = new System.Drawing.Size(70, 33);
            this.txtHeader15.TabIndex = 66;
            this.txtHeader15.Text = "MS返却";
            this.txtHeader15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader14
            // 
            this.txtHeader14.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader14.Location = new System.Drawing.Point(792, 216);
            this.txtHeader14.Name = "txtHeader14";
            this.txtHeader14.Size = new System.Drawing.Size(70, 33);
            this.txtHeader14.TabIndex = 65;
            this.txtHeader14.Text = "契約者返却";
            this.txtHeader14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader13
            // 
            this.txtHeader13.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader13.Location = new System.Drawing.Point(723, 216);
            this.txtHeader13.Name = "txtHeader13";
            this.txtHeader13.Size = new System.Drawing.Size(70, 33);
            this.txtHeader13.TabIndex = 64;
            this.txtHeader13.Text = "エスカレ中";
            this.txtHeader13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader12
            // 
            this.txtHeader12.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader12.Location = new System.Drawing.Point(654, 216);
            this.txtHeader12.Name = "txtHeader12";
            this.txtHeader12.Size = new System.Drawing.Size(70, 33);
            this.txtHeader12.TabIndex = 63;
            this.txtHeader12.Text = "不着";
            this.txtHeader12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader11
            // 
            this.txtHeader11.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader11.Location = new System.Drawing.Point(585, 216);
            this.txtHeader11.Name = "txtHeader11";
            this.txtHeader11.Size = new System.Drawing.Size(70, 33);
            this.txtHeader11.TabIndex = 62;
            this.txtHeader11.Text = "返却済";
            this.txtHeader11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader10
            // 
            this.txtHeader10.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader10.Location = new System.Drawing.Point(516, 216);
            this.txtHeader10.Name = "txtHeader10";
            this.txtHeader10.Size = new System.Drawing.Size(70, 33);
            this.txtHeader10.TabIndex = 61;
            this.txtHeader10.Text = "返却処理";
            this.txtHeader10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader9
            // 
            this.txtHeader9.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader9.Location = new System.Drawing.Point(447, 216);
            this.txtHeader9.Name = "txtHeader9";
            this.txtHeader9.Size = new System.Drawing.Size(70, 33);
            this.txtHeader9.TabIndex = 60;
            this.txtHeader9.Text = "承認\r\n時間経過";
            this.txtHeader9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader8
            // 
            this.txtHeader8.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader8.Location = new System.Drawing.Point(378, 216);
            this.txtHeader8.Name = "txtHeader8";
            this.txtHeader8.Size = new System.Drawing.Size(70, 33);
            this.txtHeader8.TabIndex = 59;
            this.txtHeader8.Text = "承認";
            this.txtHeader8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader7
            // 
            this.txtHeader7.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader7.Location = new System.Drawing.Point(309, 216);
            this.txtHeader7.Name = "txtHeader7";
            this.txtHeader7.Size = new System.Drawing.Size(70, 33);
            this.txtHeader7.TabIndex = 58;
            this.txtHeader7.Text = "回答済";
            this.txtHeader7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader6
            // 
            this.txtHeader6.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader6.Location = new System.Drawing.Point(240, 216);
            this.txtHeader6.Name = "txtHeader6";
            this.txtHeader6.Size = new System.Drawing.Size(70, 33);
            this.txtHeader6.TabIndex = 57;
            this.txtHeader6.Text = "エスカレ\r\n送付";
            this.txtHeader6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader5
            // 
            this.txtHeader5.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader5.Location = new System.Drawing.Point(171, 216);
            this.txtHeader5.Name = "txtHeader5";
            this.txtHeader5.Size = new System.Drawing.Size(70, 33);
            this.txtHeader5.TabIndex = 56;
            this.txtHeader5.Text = "エスカレ\r\n登録";
            this.txtHeader5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader4
            // 
            this.txtHeader4.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader4.Location = new System.Drawing.Point(723, 198);
            this.txtHeader4.Name = "txtHeader4";
            this.txtHeader4.Size = new System.Drawing.Size(277, 19);
            this.txtHeader4.TabIndex = 54;
            this.txtHeader4.Text = "エスカレ回答";
            this.txtHeader4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader3
            // 
            this.txtHeader3.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader3.Location = new System.Drawing.Point(171, 198);
            this.txtHeader3.Name = "txtHeader3";
            this.txtHeader3.Size = new System.Drawing.Size(553, 19);
            this.txtHeader3.TabIndex = 52;
            this.txtHeader3.Text = "ステータス";
            this.txtHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader2
            // 
            this.txtHeader2.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader2.Location = new System.Drawing.Point(118, 198);
            this.txtHeader2.Name = "txtHeader2";
            this.txtHeader2.Size = new System.Drawing.Size(54, 51);
            this.txtHeader2.TabIndex = 51;
            this.txtHeader2.Text = "合計";
            this.txtHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeader1
            // 
            this.txtHeader1.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHeader1.Location = new System.Drawing.Point(15, 198);
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.Size = new System.Drawing.Size(104, 51);
            this.txtHeader1.TabIndex = 50;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopy.Location = new System.Drawing.Point(828, 540);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(110, 31);
            this.btnCopy.TabIndex = 108;
            this.btnCopy.Text = "コピー";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(75, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // frmMSPB006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1028, 612);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtMSRtnTimeOverSum);
            this.Controls.Add(this.txtMSRtnSum);
            this.Controls.Add(this.txtContractorRtnSum);
            this.Controls.Add(this.txtEscProcessSum);
            this.Controls.Add(this.txtNoneArrivedSum);
            this.Controls.Add(this.txtReturnedSum);
            this.Controls.Add(this.txtRetrunProcessSum);
            this.Controls.Add(this.txtApprovalTimeOverSum);
            this.Controls.Add(this.txtApprovalSum);
            this.Controls.Add(this.txtResponsedSum);
            this.Controls.Add(this.txtEscSendSum);
            this.Controls.Add(this.txtEscRegistSum);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.txtHeader18);
            this.Controls.Add(this.txtHeader17);
            this.Controls.Add(this.txtHeader16);
            this.Controls.Add(this.txtHeader15);
            this.Controls.Add(this.txtHeader14);
            this.Controls.Add(this.txtHeader13);
            this.Controls.Add(this.txtHeader12);
            this.Controls.Add(this.txtHeader11);
            this.Controls.Add(this.txtHeader10);
            this.Controls.Add(this.txtHeader9);
            this.Controls.Add(this.txtHeader8);
            this.Controls.Add(this.txtHeader7);
            this.Controls.Add(this.txtHeader6);
            this.Controls.Add(this.txtHeader5);
            this.Controls.Add(this.txtHeader4);
            this.Controls.Add(this.txtHeader3);
            this.Controls.Add(this.txtHeader2);
            this.Controls.Add(this.txtHeader1);
            this.Controls.Add(this.btnCalcSum);
            this.Controls.Add(this.lblComment2);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.lblComment1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB006";
            this.Text = "MS 私物返却管理DB 集計";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ESCALATION_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        daofrmMSPB006 dao = new daofrmMSPB006("DBConnection");

        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB006()
        {
            InitializeComponent();

            this.ActiveControl = this.btnCalcSum;

            this.dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Inset;
            this.dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
            this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;


            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion
        #region イベント

        #region 集計ボタン押下
        private void Btn_CalcSum_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Info("集計処理 開始");

                int idx = 0;
                int SeqNo = 0;
                string sDtFrom = null;
                string sDtTo = null;
                DateTime DtFrom;
                DateTime DtTo;
                if (!string.IsNullOrEmpty(this.txtDateFrom.Text.ToString()))
                {
                    if (!DateTime.TryParseExact(this.txtDateFrom.Text.ToString(),"yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DtFrom))
                    {                        
                        new clsMessageBox().MessageBoxOKOnly("期間集計の開始日の日付は yyyy-mm-dd 形式で入力してください。", "警告", MessageBoxIcon.Warning);
                        this.ActiveControl = this.txtDateFrom;
                        return;
                    }
                    else
                    {
                        sDtFrom = DtFrom.ToString("yyyyMMdd");
                    }
                }
                if (!string.IsNullOrEmpty(this.txtDateTo.Text.ToString()))
                {                    
                    if (!DateTime.TryParseExact(this.txtDateTo.Text.ToString(), "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DtTo))
                    {                        
                        new clsMessageBox().MessageBoxOKOnly("期間集計の終了日の日付は yyyy-mm-dd 形式で入力してください。", "警告", MessageBoxIcon.Warning);
                        this.ActiveControl = this.txtDateTo;
                        return;
                    }
                    else
                    {
                        sDtTo = DtTo.ToString("yyyyMMdd");
                    }
                }

                this.Cursor = Cursors.WaitCursor;

                // CntTblとCntTbl_Sumに集計項目ごと
                int[] CntTbl        = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] CntTbl_Sum    = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                
                // 
                DataTable dt = dao.Select_SearchDate_T_Escalation(sDtFrom, sDtTo);

                dataGridView1.Rows.Clear();

                if (dt.Rows.Count <= 0)                
                {
                    goto Exit1;
                }

                string BeforeReceptionDate = dt.Rows[0]["REGIST_DATE"].ToString();

                _logger.Debug("Count =" + dt.Rows.Count.ToString());
            
            Restart:
                while (true)
                {
                    _logger.Debug("In =" + idx.ToString());
                    if (idx >= dt.Rows.Count)
                    {
                        break;
                    }
                    if (dt.Rows[idx]["REGIST_DATE"].ToString() == BeforeReceptionDate)
                    {
                        CntTbl[0] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 合計

                        switch (dt.Rows[idx]["STATUS"].ToString())
                        {
                            case "0": // エスカレ登録 
                                CntTbl[1] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // エスカレ登録件数
                                break;
                            case "1": // エスカレ送付
                                CntTbl[2] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // エスカレ送付件数
                                break;
                            case "2": // 回答済
                                CntTbl[3] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 回答済件数
                                break;
                            case "3": // 承認
                                CntTbl[4] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 承認件数
                                break;                            
                            case "4": // 承認期間経過
                                CntTbl[5] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 承認期間経過件数
                                break;
                            case "5": // 返却処理
                                CntTbl[6] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 返却処理件数
                                break;
                            case "6": // 返却
                                CntTbl[7] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 返却件数
                                break;
                            case "9": // 不着
                                CntTbl[8] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 不着件数
                                break;
                            default:
                                break;
                        }
                        switch (dt.Rows[idx]["ESCALATION_RESPONSE"].ToString())
                        {
                            case "0": // エスカレ中 
                                CntTbl[9] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // エスカレ中件数
                                break;
                            case "1": // 契約者返却
                                CntTbl[10] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 契約者返却件数
                                break;
                            case "2": // MS返却
                                CntTbl[11] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // MS返却件数
                                break;
                            case "3": // 期間経過
                                CntTbl[12] += int.Parse(dt.Rows[idx]["COUNT"].ToString()); // 期間経過件数
                                break;
                            default:
                                break;
                        }
                        idx++;
                    }
                    else
                    {
                        break;
                    }
                }
                _logger.Debug("Out =" + idx.ToString());

                SeqNo++;

                this.T_ESCALATION_BindingSource.List.Add
                (
                    new dao.daofrmMSPB006.TotalResult_T_ESCALATION()
                    {
                        No = SeqNo.ToString(),
                        RegistDate = BeforeReceptionDate.Insert(6, "-").Insert(4, "-"),
                        SumValue = CntTbl[0].ToString(),
                        EscRegist = CntTbl[1].ToString(),
                        EscSend = CntTbl[2].ToString(),
                        Responsed = CntTbl[3].ToString(),
                        Approval = CntTbl[4].ToString(),
                        ApprovalTimeOver = CntTbl[5].ToString(),
                        RetrunProcess = CntTbl[6].ToString(),
                        Returned = CntTbl[7].ToString(),
                        NoneArrived = CntTbl[8].ToString(),
                        EscProcess = CntTbl[9].ToString(),
                        ContractorRtn = CntTbl[10].ToString(),
                        MSRtn = CntTbl[11].ToString(),
                        MSRtnTimeOver = CntTbl[12].ToString()
                    }
                );                
                for (int i = 0; i < 13; i++)                
                {
                    CntTbl_Sum[i] += CntTbl[i];
                    CntTbl[i] = 0;
                }
                if (idx < dt.Rows.Count)
                {
                    BeforeReceptionDate = dt.Rows[idx]["REGIST_DATE"].ToString();
                    goto Restart;
                }
            
            Exit1:
                this.txtSumValue.Text = CntTbl_Sum[0].ToString();
                this.txtEscRegistSum.Text = CntTbl_Sum[1].ToString();
                this.txtEscSendSum.Text = CntTbl_Sum[2].ToString();
                this.txtResponsedSum.Text = CntTbl_Sum[3].ToString();
                this.txtApprovalSum.Text = CntTbl_Sum[4].ToString();
                this.txtApprovalTimeOverSum.Text = CntTbl_Sum[5].ToString();
                this.txtRetrunProcessSum.Text = CntTbl_Sum[6].ToString();
                this.txtReturnedSum.Text = CntTbl_Sum[7].ToString();
                this.txtNoneArrivedSum.Text = CntTbl_Sum[8].ToString();
                this.txtEscProcessSum.Text = CntTbl_Sum[9].ToString();
                this.txtContractorRtnSum.Text = CntTbl_Sum[10].ToString();
                this.txtMSRtnSum.Text = CntTbl_Sum[11].ToString();
                this.txtMSRtnTimeOverSum.Text = CntTbl_Sum[12].ToString();                
                    
                dt.Clear();
                dataGridView1.ClearSelection();

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                }
                
                
            }
            catch (Exception ex)
            {
                _logger.Fatal("集計処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("集計処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);                
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _logger.Info("集計処理 終了");                
            }

        }
        #endregion

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("集計：戻るボタン押下");
            this.Close();
        }
        #endregion

        #region コピーボタン
        /// <summary>
        /// コピーボタン
        /// </summary>
        /// <remarks></remarks>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            
            string Text;
            Text = "\t\t\t" + this.txtHeader3.Text + "\t\t\t\t\t\t\t\t" +
                   this.txtHeader4.Text + "\r\n" +                   
                   "\t\t" + "合計" + "\t" +
                   this.txtHeader5.Text.Replace(Environment.NewLine, "") + "\t" +
                   this.txtHeader6.Text.Replace(Environment.NewLine, "") + "\t" +
                   this.txtHeader7.Text + "\t" +
                   this.txtHeader8.Text + "\t" +
                   this.txtHeader9.Text.Replace(Environment.NewLine, "") + "\t" +
                   this.txtHeader10.Text + "\t" +
                   this.txtHeader11.Text + "\t" +                   
                   this.txtHeader12.Text + "\t" +
                   this.txtHeader13.Text + "\t" +
                   this.txtHeader14.Text + "\t" +
                   this.txtHeader15.Text + "\t" +
                   this.txtHeader16.Text + "\r\n" +
                   this.txtHeader17.Text + "\t" +
                   this.txtHeader18.Text + "\t" +                   
                   this.txtSumValue.Text + "\t" +
                   this.txtEscRegistSum.Text + "\t" +
                   this.txtEscSendSum.Text + "\t" +                   
                   this.txtResponsedSum.Text + "\t" +
                   this.txtApprovalSum.Text + "\t" +
                   this.txtApprovalTimeOverSum.Text + "\t" +
                   this.txtRetrunProcessSum.Text + "\t" +
                   this.txtReturnedSum.Text + "\t" +
                   this.txtNoneArrivedSum.Text + "\t" +
                   this.txtEscProcessSum.Text + "\t" +
                   this.txtContractorRtnSum.Text + "\t" +
                   this.txtMSRtnSum.Text + "\t" +
                   this.txtMSRtnTimeOverSum.Text + "\r\n";            

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    Text += dataGridView1[column.Index, row.Index].Value.ToString() + "\t";
                }
                Text = Text.Substring(0, Text.Length - 1) + "\r\n";
            }
            Clipboard.SetDataObject(Text, true);
            
        }

        #endregion

        #region 機関集計の日付_KeyPress
        private void Date_KeyPress(object sender, KeyPressEventArgs e)
        {            
            //0～9と、'/', '-', バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' &&
                e.KeyChar != '/' && e.KeyChar != '-')
            {
                e.Handled = true;
            }            
        }
        #endregion

        #endregion
    }
}
