using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using log4net;
using dnp.nulcommon.dao;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using MSPB.Common;
using System.Drawing;

namespace MSPB.MSPB006.form
{

    /// <summary>
    /// エスカレシート出力画面
    /// </summary>
    class frmMSPB006 : Form
    {
        #region デザイン
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
        private System.Windows.Forms.TextBox txtStReplCollect;
        private System.Windows.Forms.TextBox txtStReplSend;
        private System.Windows.Forms.TextBox txtStCollectReq;
        private System.Windows.Forms.TextBox txtStShipReq;
        private System.Windows.Forms.TextBox txtSeReplCollect;
        private System.Windows.Forms.TextBox txtSeReplSend;
        private System.Windows.Forms.TextBox txtSeCollectReq;
        private System.Windows.Forms.TextBox txtSeShipReq;
        private System.Windows.Forms.TextBox txtReReplCollect;
        private System.Windows.Forms.TextBox txtReReplSend;
        private System.Windows.Forms.TextBox txtReCollectReq;
        private System.Windows.Forms.TextBox txtReShipReq;
        private System.Windows.Forms.TextBox txtSumValue;
        private System.Windows.Forms.TextBox txtHeader24;
        private System.Windows.Forms.TextBox txtHeader23;
        private System.Windows.Forms.TextBox txtHeader18;
        private System.Windows.Forms.TextBox txtHeader17;
        private System.Windows.Forms.TextBox txtHeader16;
        private System.Windows.Forms.TextBox txtHeader15;
        private System.Windows.Forms.TextBox txtHeader14;
        private System.Windows.Forms.TextBox txtHeader13;
        private System.Windows.Forms.TextBox txtHeader12;
        private System.Windows.Forms.TextBox txtHeader11;
        private System.Windows.Forms.TextBox txtHeader10;
        private System.Windows.Forms.TextBox txtHeader9;
        private System.Windows.Forms.TextBox txtHeader8;
        private System.Windows.Forms.TextBox txtHeader7;
        private System.Windows.Forms.TextBox txtHeader5;
        private System.Windows.Forms.TextBox txtHeader3;
        private System.Windows.Forms.TextBox txtHeader2;
        private System.Windows.Forms.TextBox txtHeader1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
        

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtStReplCollect = new System.Windows.Forms.TextBox();
            this.txtStReplSend = new System.Windows.Forms.TextBox();
            this.txtStCollectReq = new System.Windows.Forms.TextBox();
            this.txtStShipReq = new System.Windows.Forms.TextBox();
            this.txtSeReplCollect = new System.Windows.Forms.TextBox();
            this.txtSeReplSend = new System.Windows.Forms.TextBox();
            this.txtSeCollectReq = new System.Windows.Forms.TextBox();
            this.txtSeShipReq = new System.Windows.Forms.TextBox();
            this.txtReReplCollect = new System.Windows.Forms.TextBox();
            this.txtReReplSend = new System.Windows.Forms.TextBox();
            this.txtReCollectReq = new System.Windows.Forms.TextBox();
            this.txtReShipReq = new System.Windows.Forms.TextBox();
            this.txtSumValue = new System.Windows.Forms.TextBox();
            this.txtHeader24 = new System.Windows.Forms.TextBox();
            this.txtHeader23 = new System.Windows.Forms.TextBox();
            this.txtHeader18 = new System.Windows.Forms.TextBox();
            this.txtHeader17 = new System.Windows.Forms.TextBox();
            this.txtHeader16 = new System.Windows.Forms.TextBox();
            this.txtHeader15 = new System.Windows.Forms.TextBox();
            this.txtHeader14 = new System.Windows.Forms.TextBox();
            this.txtHeader13 = new System.Windows.Forms.TextBox();
            this.txtHeader12 = new System.Windows.Forms.TextBox();
            this.txtHeader11 = new System.Windows.Forms.TextBox();
            this.txtHeader10 = new System.Windows.Forms.TextBox();
            this.txtHeader9 = new System.Windows.Forms.TextBox();
            this.txtHeader8 = new System.Windows.Forms.TextBox();
            this.txtHeader7 = new System.Windows.Forms.TextBox();
            this.txtHeader5 = new System.Windows.Forms.TextBox();
            this.txtHeader3 = new System.Windows.Forms.TextBox();
            this.txtHeader2 = new System.Windows.Forms.TextBox();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(988, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(369, 14);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(244, 24);
            this.header0.TabIndex = 0;
            this.header0.Text = "MS　私物返却管理DB";
            // 
            // header1
            // 
            this.header1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.header1.AutoSize = true;
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(458, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(60, 24);
            this.header1.TabIndex = 0;
            this.header1.Text = "集計";
            // 
            // btnCalcSum
            // 
            this.btnCalcSum.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCalcSum.ForeColor = System.Drawing.Color.Black;
            this.btnCalcSum.Location = new System.Drawing.Point(808, 149);
            this.btnCalcSum.Name = "btnCalcSum";
            this.btnCalcSum.Size = new System.Drawing.Size(76, 27);
            this.btnCalcSum.TabIndex = 13;
            this.btnCalcSum.Text = "集計";
            this.btnCalcSum.UseVisualStyleBackColor = true;
            // 
            // lblComment2
            // 
            this.lblComment2.AutoSize = true;
            this.lblComment2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment2.Location = new System.Drawing.Point(359, 154);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(112, 16);
            this.lblComment2.TabIndex = 12;
            this.lblComment2.Text = "（yyyy-mm-dd）";
            // 
            // txtDateTo
            // 
            this.txtDateTo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateTo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDateTo.Location = new System.Drawing.Point(204, 150);
            this.txtDateTo.MaxLength = 10;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(121, 23);
            this.txtDateTo.TabIndex = 11;
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLine.Location = new System.Drawing.Point(162, 159);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(42, 1);
            this.lblLine.TabIndex = 10;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDateFrom.Location = new System.Drawing.Point(41, 150);
            this.txtDateFrom.MaxLength = 10;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(121, 23);
            this.txtDateFrom.TabIndex = 9;
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComment1.Location = new System.Drawing.Point(55, 129);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(59, 13);
            this.lblComment1.TabIndex = 8;
            this.lblComment1.Text = "期間集計";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(8, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(993, 156);
            this.dataGridView1.TabIndex = 91;
            this.dataGridView1.TabStop = false;
            // 
            // txtStReplCollect
            // 
            this.txtStReplCollect.BackColor = System.Drawing.Color.LightGray;
            this.txtStReplCollect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStReplCollect.Location = new System.Drawing.Point(912, 234);
            this.txtStReplCollect.Name = "txtStReplCollect";
            this.txtStReplCollect.ReadOnly = true;
            this.txtStReplCollect.Size = new System.Drawing.Size(73, 19);
            this.txtStReplCollect.TabIndex = 86;
            this.txtStReplCollect.TabStop = false;
            this.txtStReplCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStReplSend
            // 
            this.txtStReplSend.BackColor = System.Drawing.Color.LightGray;
            this.txtStReplSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStReplSend.Location = new System.Drawing.Point(843, 234);
            this.txtStReplSend.Name = "txtStReplSend";
            this.txtStReplSend.ReadOnly = true;
            this.txtStReplSend.Size = new System.Drawing.Size(70, 19);
            this.txtStReplSend.TabIndex = 85;
            this.txtStReplSend.TabStop = false;
            this.txtStReplSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStCollectReq
            // 
            this.txtStCollectReq.BackColor = System.Drawing.Color.LightGray;
            this.txtStCollectReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStCollectReq.Location = new System.Drawing.Point(756, 234);
            this.txtStCollectReq.Name = "txtStCollectReq";
            this.txtStCollectReq.ReadOnly = true;
            this.txtStCollectReq.Size = new System.Drawing.Size(88, 19);
            this.txtStCollectReq.TabIndex = 84;
            this.txtStCollectReq.TabStop = false;
            this.txtStCollectReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStShipReq
            // 
            this.txtStShipReq.BackColor = System.Drawing.Color.LightGray;
            this.txtStShipReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStShipReq.Location = new System.Drawing.Point(687, 234);
            this.txtStShipReq.Name = "txtStShipReq";
            this.txtStShipReq.ReadOnly = true;
            this.txtStShipReq.Size = new System.Drawing.Size(70, 19);
            this.txtStShipReq.TabIndex = 83;
            this.txtStShipReq.TabStop = false;
            this.txtStShipReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSeReplCollect
            // 
            this.txtSeReplCollect.BackColor = System.Drawing.Color.LightGray;
            this.txtSeReplCollect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeReplCollect.Location = new System.Drawing.Point(634, 234);
            this.txtSeReplCollect.Name = "txtSeReplCollect";
            this.txtSeReplCollect.ReadOnly = true;
            this.txtSeReplCollect.Size = new System.Drawing.Size(54, 19);
            this.txtSeReplCollect.TabIndex = 82;
            this.txtSeReplCollect.TabStop = false;
            this.txtSeReplCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSeReplSend
            // 
            this.txtSeReplSend.BackColor = System.Drawing.Color.LightGray;
            this.txtSeReplSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeReplSend.Location = new System.Drawing.Point(581, 234);
            this.txtSeReplSend.Name = "txtSeReplSend";
            this.txtSeReplSend.ReadOnly = true;
            this.txtSeReplSend.Size = new System.Drawing.Size(54, 19);
            this.txtSeReplSend.TabIndex = 81;
            this.txtSeReplSend.TabStop = false;
            this.txtSeReplSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSeCollectReq
            // 
            this.txtSeCollectReq.BackColor = System.Drawing.Color.LightGray;
            this.txtSeCollectReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeCollectReq.Location = new System.Drawing.Point(511, 234);
            this.txtSeCollectReq.Name = "txtSeCollectReq";
            this.txtSeCollectReq.ReadOnly = true;
            this.txtSeCollectReq.Size = new System.Drawing.Size(71, 19);
            this.txtSeCollectReq.TabIndex = 80;
            this.txtSeCollectReq.TabStop = false;
            this.txtSeCollectReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSeShipReq
            // 
            this.txtSeShipReq.BackColor = System.Drawing.Color.LightGray;
            this.txtSeShipReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeShipReq.Location = new System.Drawing.Point(419, 234);
            this.txtSeShipReq.Name = "txtSeShipReq";
            this.txtSeShipReq.ReadOnly = true;
            this.txtSeShipReq.Size = new System.Drawing.Size(95, 19);
            this.txtSeShipReq.TabIndex = 79;
            this.txtSeShipReq.TabStop = false;
            this.txtSeShipReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReReplCollect
            // 
            this.txtReReplCollect.BackColor = System.Drawing.Color.LightGray;
            this.txtReReplCollect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReReplCollect.Location = new System.Drawing.Point(366, 234);
            this.txtReReplCollect.Name = "txtReReplCollect";
            this.txtReReplCollect.ReadOnly = true;
            this.txtReReplCollect.Size = new System.Drawing.Size(54, 19);
            this.txtReReplCollect.TabIndex = 78;
            this.txtReReplCollect.TabStop = false;
            this.txtReReplCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReReplSend
            // 
            this.txtReReplSend.BackColor = System.Drawing.Color.LightGray;
            this.txtReReplSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReReplSend.Location = new System.Drawing.Point(313, 234);
            this.txtReReplSend.Name = "txtReReplSend";
            this.txtReReplSend.ReadOnly = true;
            this.txtReReplSend.Size = new System.Drawing.Size(54, 19);
            this.txtReReplSend.TabIndex = 77;
            this.txtReReplSend.TabStop = false;
            this.txtReReplSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReCollectReq
            // 
            this.txtReCollectReq.BackColor = System.Drawing.Color.LightGray;
            this.txtReCollectReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReCollectReq.Location = new System.Drawing.Point(240, 234);
            this.txtReCollectReq.Name = "txtReCollectReq";
            this.txtReCollectReq.ReadOnly = true;
            this.txtReCollectReq.Size = new System.Drawing.Size(74, 19);
            this.txtReCollectReq.TabIndex = 76;
            this.txtReCollectReq.TabStop = false;
            this.txtReCollectReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReShipReq
            // 
            this.txtReShipReq.BackColor = System.Drawing.Color.LightGray;
            this.txtReShipReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReShipReq.Location = new System.Drawing.Point(164, 234);
            this.txtReShipReq.Name = "txtReShipReq";
            this.txtReShipReq.ReadOnly = true;
            this.txtReShipReq.Size = new System.Drawing.Size(77, 19);
            this.txtReShipReq.TabIndex = 75;
            this.txtReShipReq.TabStop = false;
            this.txtReShipReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSumValue
            // 
            this.txtSumValue.BackColor = System.Drawing.Color.LightGray;
            this.txtSumValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSumValue.Location = new System.Drawing.Point(111, 234);
            this.txtSumValue.Name = "txtSumValue";
            this.txtSumValue.ReadOnly = true;
            this.txtSumValue.Size = new System.Drawing.Size(54, 19);
            this.txtSumValue.TabIndex = 74;
            this.txtSumValue.TabStop = false;
            this.txtSumValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader24
            // 
            this.txtHeader24.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader24.Location = new System.Drawing.Point(40, 234);
            this.txtHeader24.Name = "txtHeader24";
            this.txtHeader24.ReadOnly = true;
            this.txtHeader24.Size = new System.Drawing.Size(72, 19);
            this.txtHeader24.TabIndex = 73;
            this.txtHeader24.TabStop = false;
            this.txtHeader24.Text = "登録日";
            this.txtHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader23
            // 
            this.txtHeader23.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader23.Location = new System.Drawing.Point(8, 234);
            this.txtHeader23.Name = "txtHeader23";
            this.txtHeader23.ReadOnly = true;
            this.txtHeader23.Size = new System.Drawing.Size(33, 19);
            this.txtHeader23.TabIndex = 72;
            this.txtHeader23.TabStop = false;
            this.txtHeader23.Text = "NO";
            this.txtHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader18
            // 
            this.txtHeader18.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader18.Location = new System.Drawing.Point(912, 216);
            this.txtHeader18.Name = "txtHeader18";
            this.txtHeader18.ReadOnly = true;
            this.txtHeader18.Size = new System.Drawing.Size(73, 19);
            this.txtHeader18.TabIndex = 67;
            this.txtHeader18.TabStop = false;
            this.txtHeader18.Text = "時間経過";
            this.txtHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader17
            // 
            this.txtHeader17.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader17.Location = new System.Drawing.Point(843, 216);
            this.txtHeader17.Name = "txtHeader17";
            this.txtHeader17.ReadOnly = true;
            this.txtHeader17.Size = new System.Drawing.Size(70, 19);
            this.txtHeader17.TabIndex = 66;
            this.txtHeader17.TabStop = false;
            this.txtHeader17.Text = "MS返却";
            this.txtHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader16
            // 
            this.txtHeader16.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader16.Location = new System.Drawing.Point(756, 216);
            this.txtHeader16.Name = "txtHeader16";
            this.txtHeader16.ReadOnly = true;
            this.txtHeader16.Size = new System.Drawing.Size(88, 19);
            this.txtHeader16.TabIndex = 65;
            this.txtHeader16.TabStop = false;
            this.txtHeader16.Text = "契約者返却";
            this.txtHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader15
            // 
            this.txtHeader15.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader15.Location = new System.Drawing.Point(687, 216);
            this.txtHeader15.Name = "txtHeader15";
            this.txtHeader15.ReadOnly = true;
            this.txtHeader15.Size = new System.Drawing.Size(70, 19);
            this.txtHeader15.TabIndex = 64;
            this.txtHeader15.TabStop = false;
            this.txtHeader15.Text = "エスカレ中";
            this.txtHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader14
            // 
            this.txtHeader14.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader14.Location = new System.Drawing.Point(634, 216);
            this.txtHeader14.Name = "txtHeader14";
            this.txtHeader14.ReadOnly = true;
            this.txtHeader14.Size = new System.Drawing.Size(54, 19);
            this.txtHeader14.TabIndex = 63;
            this.txtHeader14.TabStop = false;
            this.txtHeader14.Text = "不着";
            this.txtHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader13
            // 
            this.txtHeader13.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader13.Location = new System.Drawing.Point(581, 216);
            this.txtHeader13.Name = "txtHeader13";
            this.txtHeader13.ReadOnly = true;
            this.txtHeader13.Size = new System.Drawing.Size(54, 19);
            this.txtHeader13.TabIndex = 62;
            this.txtHeader13.TabStop = false;
            this.txtHeader13.Text = "返却済";
            this.txtHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader12
            // 
            this.txtHeader12.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader12.Location = new System.Drawing.Point(511, 216);
            this.txtHeader12.Name = "txtHeader12";
            this.txtHeader12.ReadOnly = true;
            this.txtHeader12.Size = new System.Drawing.Size(71, 19);
            this.txtHeader12.TabIndex = 61;
            this.txtHeader12.TabStop = false;
            this.txtHeader12.Text = "返却処理";
            this.txtHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader11
            // 
            this.txtHeader11.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader11.Location = new System.Drawing.Point(419, 216);
            this.txtHeader11.Name = "txtHeader11";
            this.txtHeader11.ReadOnly = true;
            this.txtHeader11.Size = new System.Drawing.Size(95, 19);
            this.txtHeader11.TabIndex = 60;
            this.txtHeader11.TabStop = false;
            this.txtHeader11.Text = "承認時間経過";
            this.txtHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader10
            // 
            this.txtHeader10.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader10.Location = new System.Drawing.Point(366, 216);
            this.txtHeader10.Name = "txtHeader10";
            this.txtHeader10.ReadOnly = true;
            this.txtHeader10.Size = new System.Drawing.Size(54, 19);
            this.txtHeader10.TabIndex = 59;
            this.txtHeader10.TabStop = false;
            this.txtHeader10.Text = "承認";
            this.txtHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader9
            // 
            this.txtHeader9.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader9.Location = new System.Drawing.Point(313, 216);
            this.txtHeader9.Name = "txtHeader9";
            this.txtHeader9.ReadOnly = true;
            this.txtHeader9.Size = new System.Drawing.Size(54, 19);
            this.txtHeader9.TabIndex = 58;
            this.txtHeader9.TabStop = false;
            this.txtHeader9.Text = "回答済";
            this.txtHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader8
            // 
            this.txtHeader8.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader8.Location = new System.Drawing.Point(240, 216);
            this.txtHeader8.Name = "txtHeader8";
            this.txtHeader8.ReadOnly = true;
            this.txtHeader8.Size = new System.Drawing.Size(74, 19);
            this.txtHeader8.TabIndex = 57;
            this.txtHeader8.TabStop = false;
            this.txtHeader8.Text = "エスカレ送付";
            this.txtHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader7
            // 
            this.txtHeader7.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader7.Location = new System.Drawing.Point(164, 216);
            this.txtHeader7.Multiline = true;
            this.txtHeader7.Name = "txtHeader7";
            this.txtHeader7.ReadOnly = true;
            this.txtHeader7.Size = new System.Drawing.Size(77, 19);
            this.txtHeader7.TabIndex = 56;
            this.txtHeader7.TabStop = false;
            this.txtHeader7.Text = "エスカレ登録";
            this.txtHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader5
            // 
            this.txtHeader5.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader5.Location = new System.Drawing.Point(687, 198);
            this.txtHeader5.Name = "txtHeader5";
            this.txtHeader5.ReadOnly = true;
            this.txtHeader5.Size = new System.Drawing.Size(298, 19);
            this.txtHeader5.TabIndex = 54;
            this.txtHeader5.TabStop = false;
            this.txtHeader5.Text = "エスカレ回答";
            this.txtHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader3
            // 
            this.txtHeader3.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader3.Location = new System.Drawing.Point(164, 198);
            this.txtHeader3.Name = "txtHeader3";
            this.txtHeader3.ReadOnly = true;
            this.txtHeader3.Size = new System.Drawing.Size(524, 19);
            this.txtHeader3.TabIndex = 52;
            this.txtHeader3.TabStop = false;
            this.txtHeader3.Text = "ステータス";
            this.txtHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader2
            // 
            this.txtHeader2.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader2.Location = new System.Drawing.Point(111, 198);
            this.txtHeader2.Multiline = true;
            this.txtHeader2.Name = "txtHeader2";
            this.txtHeader2.ReadOnly = true;
            this.txtHeader2.Size = new System.Drawing.Size(54, 37);
            this.txtHeader2.TabIndex = 51;
            this.txtHeader2.TabStop = false;
            this.txtHeader2.Text = "\r\n合計";
            this.txtHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeader1
            // 
            this.txtHeader1.BackColor = System.Drawing.Color.LightGray;
            this.txtHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHeader1.Location = new System.Drawing.Point(8, 198);
            this.txtHeader1.Multiline = true;
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.ReadOnly = true;
            this.txtHeader1.Size = new System.Drawing.Size(104, 37);
            this.txtHeader1.TabIndex = 50;
            this.txtHeader1.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopy.Location = new System.Drawing.Point(831, 540);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(110, 27);
            this.btnCopy.TabIndex = 108;
            this.btnCopy.Text = "コピー";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(46, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 27);
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
            this.ClientSize = new System.Drawing.Size(1007, 612);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtStReplCollect);
            this.Controls.Add(this.txtStReplSend);
            this.Controls.Add(this.txtStCollectReq);
            this.Controls.Add(this.txtStShipReq);
            this.Controls.Add(this.txtSeReplCollect);
            this.Controls.Add(this.txtSeReplSend);
            this.Controls.Add(this.txtSeCollectReq);
            this.Controls.Add(this.txtSeShipReq);
            this.Controls.Add(this.txtReReplCollect);
            this.Controls.Add(this.txtReReplSend);
            this.Controls.Add(this.txtReCollectReq);
            this.Controls.Add(this.txtReShipReq);
            this.Controls.Add(this.txtSumValue);
            this.Controls.Add(this.txtHeader24);
            this.Controls.Add(this.txtHeader23);
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
            this.Controls.Add(this.txtHeader5);
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
            this.Text = "エスカレシート出力";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB006()
        {
            InitializeComponent();
            

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion
        #region イベント
        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("エスカレシート出力：戻るボタン押下");
            this.Close();
        }
        #endregion        
        #endregion

    }
}
