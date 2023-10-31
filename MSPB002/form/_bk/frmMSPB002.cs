﻿using System;
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
using MSPB.MSPB002.dao;
using System.Drawing;
using System.Data;

namespace MSPB.MSPB002.form
{

    /// <summary>
    /// エスカレ回答登録画面
    /// </summary>
    class frmMSPB002 : Form
    {
        #region デザイン
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Register;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView_Regist_List;        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRegistDate;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblControlNo;
        private System.Windows.Forms.Label lblContractNo;
        private System.Windows.Forms.Label lblPBContents;
        private System.Windows.Forms.Label Label_Finish_Record_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTempResponseRegist;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegistDate;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CMT_Shipping;
        private System.Windows.Forms.ComboBox comboResponse;
        private System.Windows.Forms.Label label10;

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.lblRegistDate = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblControlNo = new System.Windows.Forms.Label();
            this.lblContractNo = new System.Windows.Forms.Label();
            this.lblPBContents = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_Regist_List = new System.Windows.Forms.DataGridView();
            this.Label_Finish_Record_Num = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.header0 = new System.Windows.Forms.Label();
            this.btnTempResponseRegist = new System.Windows.Forms.Button();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegistDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CMT_Shipping = new System.Windows.Forms.Label();
            this.comboResponse = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regist_List)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Cancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Cancel.Location = new System.Drawing.Point(12, 686);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(110, 34);
            this.Btn_Cancel.TabIndex = 7;
            this.Btn_Cancel.Text = "戻る";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Register
            // 
            this.Btn_Register.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Register.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_Register.ForeColor = System.Drawing.Color.Black;
            this.Btn_Register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Register.Location = new System.Drawing.Point(627, 686);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Size = new System.Drawing.Size(110, 34);
            this.Btn_Register.TabIndex = 8;
            this.Btn_Register.Text = "回答登録";
            this.Btn_Register.UseVisualStyleBackColor = true;
            this.Btn_Register.Click += new System.EventHandler(this.btnRegistClick);
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Result.Location = new System.Drawing.Point(12, 419);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(106, 24);
            this.Result.TabIndex = 13;
            this.Result.Text = "回答登録一覧";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtControlNo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 211);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(178, 57);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "管理番号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtControlNo
            // 
            this.txtControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControlNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtControlNo.Location = new System.Drawing.Point(4, 29);
            this.txtControlNo.MaxLength = 20;
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(170, 25);
            this.txtControlNo.TabIndex = 2;
            this.txtControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CONTROL_NO_KeyDown);
            // 
            // lblRegistDate
            // 
            this.lblRegistDate.BackColor = System.Drawing.Color.White;
            this.lblRegistDate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistDate.Location = new System.Drawing.Point(4, 30);
            this.lblRegistDate.Name = "lblRegistDate";
            this.lblRegistDate.Size = new System.Drawing.Size(85, 24);
            this.lblRegistDate.TabIndex = 5;
            this.lblRegistDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductType
            // 
            this.lblProductType.BackColor = System.Drawing.Color.White;
            this.lblProductType.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProductType.Location = new System.Drawing.Point(96, 30);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(97, 24);
            this.lblProductType.TabIndex = 6;
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblControlNo
            // 
            this.lblControlNo.BackColor = System.Drawing.Color.White;
            this.lblControlNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblControlNo.Location = new System.Drawing.Point(200, 30);
            this.lblControlNo.Name = "lblControlNo";
            this.lblControlNo.Size = new System.Drawing.Size(156, 24);
            this.lblControlNo.TabIndex = 7;
            this.lblControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContractNo
            // 
            this.lblContractNo.BackColor = System.Drawing.Color.White;
            this.lblContractNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractNo.Location = new System.Drawing.Point(363, 30);
            this.lblContractNo.Name = "lblContractNo";
            this.lblContractNo.Size = new System.Drawing.Size(170, 24);
            this.lblContractNo.TabIndex = 8;
            this.lblContractNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPBContents
            // 
            this.lblPBContents.BackColor = System.Drawing.Color.White;
            this.lblPBContents.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPBContents.Location = new System.Drawing.Point(540, 30);
            this.lblPBContents.Name = "lblPBContents";
            this.lblPBContents.Size = new System.Drawing.Size(140, 24);
            this.lblPBContents.TabIndex = 9;
            this.lblPBContents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 621F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRegistDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblProductType, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblControlNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblContractNo, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPBContents, 4, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 313);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(685, 55);
            this.tableLayoutPanel2.TabIndex = 11;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel2_CellPaint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "登録日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(96, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "種別";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(200, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "管理番号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(363, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "証券番号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(540, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "内容物";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            // 
            // dataGridView_Regist_List
            // 
            this.dataGridView_Regist_List.AllowUserToAddRows = false;
            this.dataGridView_Regist_List.AllowUserToResizeColumns = false;
            this.dataGridView_Regist_List.AllowUserToResizeRows = false;
            this.dataGridView_Regist_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Regist_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Regist_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Regist_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Regist_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Regist_List.Location = new System.Drawing.Point(11, 451);
            this.dataGridView_Regist_List.Name = "dataGridView_Regist_List";
            this.dataGridView_Regist_List.ReadOnly = true;
            this.dataGridView_Regist_List.RowHeadersVisible = false;
            this.dataGridView_Regist_List.RowTemplate.Height = 21;
            this.dataGridView_Regist_List.Size = new System.Drawing.Size(730, 216);
            this.dataGridView_Regist_List.TabIndex = 10;
            // 
            // Label_Finish_Record_Num
            // 
            this.Label_Finish_Record_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Finish_Record_Num.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_Finish_Record_Num.Location = new System.Drawing.Point(573, 419);
            this.Label_Finish_Record_Num.Name = "Label_Finish_Record_Num";
            this.Label_Finish_Record_Num.Size = new System.Drawing.Size(161, 29);
            this.Label_Finish_Record_Num.TabIndex = 9;
            this.Label_Finish_Record_Num.Text = "999　件";
            this.Label_Finish_Record_Num.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(12, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "検索結果";
            // 
            // header1
            // 
            this.header1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.header1.AutoSize = true;
            this.header1.BackColor = System.Drawing.Color.Transparent;
            this.header1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(244, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(207, 36);
            this.header1.TabIndex = 1;
            this.header1.Text = "エスカレ回答登録";
            // 
            // header0
            // 
            this.header0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header0.AutoSize = true;
            this.header0.BackColor = System.Drawing.Color.Transparent;
            this.header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.header0.ForeColor = System.Drawing.Color.Black;
            this.header0.Location = new System.Drawing.Point(217, 14);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(258, 36);
            this.header0.TabIndex = 0;
            this.header0.Text = "MS　私物返却管理DB";
            // 
            // btnTempResponseRegist
            // 
            this.btnTempResponseRegist.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTempResponseRegist.Location = new System.Drawing.Point(567, 382);
            this.btnTempResponseRegist.Name = "btnTempResponseRegist";
            this.btnTempResponseRegist.Size = new System.Drawing.Size(159, 34);
            this.btnTempResponseRegist.TabIndex = 6;
            this.btnTempResponseRegist.Text = "エスカレ回答登録";
            this.btnTempResponseRegist.UseVisualStyleBackColor = true;
            this.btnTempResponseRegist.Click += new System.EventHandler(this.btnTempResponseRegistClick);
            // 
            // btnReLoad
            // 
            this.btnReLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReLoad.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReLoad.Location = new System.Drawing.Point(578, 226);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(110, 34);
            this.btnReLoad.TabIndex = 4;
            this.btnReLoad.Text = "再読込";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoadClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(12, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "読込";
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(729, 100);
            this.panelTitle.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "登録日";
            // 
            // txtRegistDate
            // 
            this.txtRegistDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRegistDate.Location = new System.Drawing.Point(23, 145);
            this.txtRegistDate.MaxLength = 8;
            this.txtRegistDate.Name = "txtRegistDate";
            this.txtRegistDate.Size = new System.Drawing.Size(114, 31);
            this.txtRegistDate.TabIndex = 1;
            this.txtRegistDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputRegistDateCheck);
            this.txtRegistDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressRegistDateCheck);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(421, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearchClick);
            // 
            // CMT_Shipping
            // 
            this.CMT_Shipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CMT_Shipping.AutoSize = true;
            this.CMT_Shipping.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CMT_Shipping.Location = new System.Drawing.Point(306, 389);
            this.CMT_Shipping.Name = "CMT_Shipping";
            this.CMT_Shipping.Size = new System.Drawing.Size(106, 24);
            this.CMT_Shipping.TabIndex = 12;
            this.CMT_Shipping.Text = "エスカレ回答";
            // 
            // comboResponse
            // 
            this.comboResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboResponse.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboResponse.Location = new System.Drawing.Point(421, 384);
            this.comboResponse.Name = "comboResponse";
            this.comboResponse.Size = new System.Drawing.Size(137, 32);
            this.comboResponse.TabIndex = 5;
            // 
            // frmMSPB002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 733);
            this.Controls.Add(this.comboResponse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRegistDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.btnTempResponseRegist);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Label_Finish_Record_Num);
            this.Controls.Add(this.dataGridView_Regist_List);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.CMT_Shipping);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Btn_Register);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB002";
            this.Text = "MS 私物返却管理DB エスカレ回答登録";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Regist_List)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 回答登録更新ステータス
        /// </summary>
        private static readonly string updateStatus = "2";
        /// <summary>
        /// ユーザ名
        /// </summary>
        private static string _userName;

        // 回答_TEMP登録件数保持変数
        private int tmtRegistCnt = 0;

        daofrmMSPB002 dao = null;
        // 回答_TEMPテーブル用DataTable
        DataTable dtResponseTmp = null;
        // エスカレテーブル用DataTable
        DataTable dtEscalation = null;
        // エスカレ回答プルダウン用DataTable
        DataTable dtEscalationResponse = null;
        private List<ResponseTMPEntity> dtos = new List<ResponseTMPEntity>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB002(string userName)
        {
            _userName = userName;
            dao = new daofrmMSPB002("DBConnection", _userName);

            InitializeComponent();

            this.ActiveControl = this.txtControlNo;

            // エスカレ回答プルダウン
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

        #region 検索ボタン押下
        private void btnSearchClick(object sender, EventArgs e)
        {

            _logger.Debug("エスカレ回答登録：検索ボタン押下");

            // 検索結果にデータがあった場合
            if (lblRegistDate.Text != "" || lblProductType.Text != "" || lblControlNo.Text != "" || lblContractNo.Text != "" || lblPBContents.Text != "")
            {
                DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録一覧に回答登録していません、登録しますか？", "エスカレ回答登録", MessageBoxIcon.Warning);
                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    // 「いいえ」の場合、検索結果をクリアして後続処理を行う
                    lblRegistDate.Text = "";
                    lblProductType.Text = "";
                    lblControlNo.Text = "";
                    lblContractNo.Text = "";
                    lblPBContents.Text = "";
                }

            }

            // 入力した管理番号の桁数チェック
            if (txtControlNo.Text.Length != 20)
            {
                new clsMessageBox().MessageBoxOKOnly("形式が異なります、再度、読み込んでください。", "エスカレ回答登録", MessageBoxIcon.Warning);
                inputMenuDefualtDisplay();
                return;
            }

            _logger.Info($"入力した管理番号（{txtControlNo.Text}）");

            try
            {
                // 回答_TEMPテーブルから入力した管理番号存在チェック
                var dtTemp = dao.select_T_RESPONSE_TMP(txtControlNo.Text);
                _logger.Info("回答_TEMPテーブル取得数 [" + dtTemp.Rows.Count + "]");

                if (dtTemp.Rows.Count <= 0)
                {
                    // エスカレテーブルから入力した管理番号存在チェック
                    dtEscalation = dao.select_T_ESCALATION(txtControlNo.Text);
                    _logger.Info("エスカレテーブル取得数 [" + dtEscalation.Rows.Count + "]");

                    if (dtEscalation.Rows.Count <= 0)
                    {
                        new clsMessageBox().MessageBoxOKOnly("エスカレ報告が存在しません。", "エスカレ回答登録", MessageBoxIcon.Warning);
                        inputMenuDefualtDisplay();
                        return;
                    }
                    else
                    {
                        // 取得したデータのステータスが「6：返却済」の場合
                        if (dtEscalation.Rows[0]["STATUS"].ToString() == "6")
                        {
                            new clsMessageBox().MessageBoxOKOnly("返却済です。", "エスカレ回答登録", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }
                        // 取得したデータのステータスが「2：回答済」の場合
                        else if (dtEscalation.Rows[0]["STATUS"].ToString() == "2")
                        {
                            DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録済です、回答内容を変更しますか？", "エスカレ回答登録", MessageBoxIcon.Warning);
                            //何が選択されたか調べる
                            if (result == DialogResult.No)
                            {
                                inputMenuDefualtDisplay();
                                return;
                            }
                        }
                        // 取得したデータのステータスが「3：承認」または「4：承認保管期間経過」の場合
                        else if (dtEscalation.Rows[0]["STATUS"].ToString() == "3" || dtEscalation.Rows[0]["STATUS"].ToString() == "4")
                        {
                            new clsMessageBox().MessageBoxOKOnly("承認済です。", "エスカレ回答登録", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }
                        // 取得したデータのステータスが「5：返却処理」の場合
                        else if (dtEscalation.Rows[0]["STATUS"].ToString() == "5")
                        {
                            new clsMessageBox().MessageBoxOKOnly("返却処理中です。", "エスカレ回答登録", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }

                        lblRegistDate.Text = dtEscalation.Rows[0]["REGIST_DATE"].ToString();
                        lblProductType.Text = dtEscalation.Rows[0]["PRODUCT_TYPE"].ToString();
                        lblControlNo.Text = dtEscalation.Rows[0]["CONTROL_NO"].ToString();
                        lblContractNo.Text = dtEscalation.Rows[0]["CONTRACT_NO"].ToString();
                        lblPBContents.Text = dtEscalation.Rows[0]["PERSONAL_BELONGINGS_INFO"].ToString();
                    }
                }
                else
                {
                    _logger.Info($"入力した管理番号（{txtControlNo.Text}）は回答登録一覧と重複しています、回答登録済｡");
                    new clsMessageBox().MessageBoxOKOnly("回答登録一覧と重複しています、回答登録済｡", "エスカレ回答登録", MessageBoxIcon.Warning);
                    inputMenuDefualtDisplay();
                    return;
                }

            }
            catch (Exception ex)
            {
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エスカレ回答登録", MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答登録：戻るボタン押下");

            // 「検索結果」または「回答登録一覧」にデータが存在した場合。
            if (lblRegistDate.Text != "" || 
                lblProductType.Text != "" || 
                lblControlNo.Text != "" || 
                lblContractNo.Text != "" || 
                lblPBContents.Text != "" ||
                dataGridView_Regist_List.Rows.Count > 0)
            {
                DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録をしていません、登録を中止・一覧を削除しますか？", "エスカレ回答登録", MessageBoxIcon.Warning);
                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    if (dataGridView_Regist_List.Rows.Count > 0)
                    {
                        try
                        {
                            // トランザクション開始
                            dao.BeginTransaction();

                            // 回答_TEMPテーブルデータ削除
                            dao.delete_T_RESPONSE_TMP();

                            // コミット
                            dao.Commit();
                        }
                        catch (Exception ex)
                        {
                            // ロールバック
                            dao.Rollback();
                            new clsMessageBox().MessageBoxOKOnly("回答_TEMPデータ削除でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エスカレ回答登録", MessageBoxIcon.Error);
                            return;
                        }
                    }
                    this.Close();                    
                }
                else
                {
                    txtControlNo.Focus();
                    return;
                }
            }
            else
            {
                this.Close();
            }            
        }
        #endregion

        #region 管理番号入力欄エンターキー処理
        private void textBox_CONTROL_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchClick(sender, e);
            }
        }
        #endregion

        #region 登録日入力制限（数値のみ）＆日付形式チェック
        private void inputRegistDateCheck(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!DateTime.TryParseExact(txtRegistDate.Text, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var d))
                {
                    new clsMessageBox().MessageBoxOKOnly("登録日の形式が異なります、日付を確認してください。", "エスカレ回答登録", MessageBoxIcon.Warning);
                    txtRegistDate.Focus();
                    return;
                }
                else
                {
                    txtControlNo.Focus();
                }
            }
        }

        private void keyPressRegistDateCheck(object sender, KeyPressEventArgs e)
        {
            //バックスペースが押された時は有効（Deleteキーも有効）
            if (e.KeyChar == '\b')
            {
                return;
            }

            //数値0～9以外が押された時はイベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 再読込ボタン押下    
        private void btnReLoadClick(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答登録：再読込ボタン押下");
            // 入力欄初期化
            inputMenuDefualtDisplay();
        }
        #endregion

        #region 回答登録ボタン押下
        private void btnRegistClick(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答登録：回答登録ボタン押下");

            // 検索結果にデータが存在した場合
            if (lblRegistDate.Text != "" ||
                lblProductType.Text != "" ||
                lblControlNo.Text != "" ||
                lblContractNo.Text != "" ||
                lblPBContents.Text != "")
            {
                DialogResult result = new clsMessageBox().MessageBoxYesNo("回収登録一覧に登録していません、登録しますか？", "エスカレ回答登録", MessageBoxIcon.Warning);
                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    // エスカレ回答登録ボタン押下処理
                    btnTempResponseRegistClick(sender, e);
                    return;
                }
                else
                {
                    // 検索結果クリア
                    inputMenuDefualtDisplay();
                    return;
                }
            }

            DialogResult result1 = new clsMessageBox().MessageBoxYesNo("エスカレ回答を登録します、よろしいですか？", "エスカレ回答登録", MessageBoxIcon.Warning);
            //何が選択されたか調べる
            if (result1 == DialogResult.Yes)
            {
                try
                {
                    // トランザクション開始
                    dao.BeginTransaction();

                    foreach (DataRow row in dtResponseTmp.Rows)
                    {
                        // エスカレ回答登録処理
                        dao.update_T_ESCALATION(updateStatus, txtRegistDate.Text, row["CONTROL_NO"].ToString(), _userName, row["ESCALATION_RESPONSE"].ToString());
                    }

                    // 回答_TEMPテーブルデータ削除処理
                    dao.delete_T_RESPONSE_TMP();

                    // コミット
                    dao.Commit();

                }
                catch (Exception ex)
                {
                    // ロールバック
                    dao.Rollback();
                    _logger.Info("エスカレ回答登録処理でエラーが発生しました。" + ex.ToString());
                    new clsMessageBox().MessageBoxOKOnly("エスカレ回答登録処理でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "私物登録", MessageBoxIcon.Error);
                    return;
                }

                // GridView再読込
                dataGridView_Response_List_Binding();
                // 画面初期化
                tmtRegistCnt = 0;
                inputMenuDefualtDisplay();
            }
            else
            {
                // 管理番号TextBoxにフォーカス
                txtControlNo.Focus();
                return;
            }
        }
        #endregion

        #region セルの背景色を変更
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
            }
        }

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
            }
            else if (e.Row == 1)
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
            }
        }
        #endregion

        #endregion

        #region メソッド

        #region 入力項目初期化
        private void inputMenuDefualtDisplay()
        {
            txtRegistDate.Text = System.DateTime.Now.ToString("yyyyMMdd");
            txtControlNo.Text = "";
            txtControlNo.Focus();

            comboResponse.SelectedIndex = 0;

            lblRegistDate.Text = "";
            lblProductType.Text = "";
            lblControlNo.Text = "";
            lblContractNo.Text = "";
            lblPBContents.Text = "";

            Label_Finish_Record_Num.Text = tmtRegistCnt.ToString("D3") + " 件";

        }
        #endregion

        #region エスカレ回答プルダウン設定
        private void setEscalationReponse()
        {
            try
            {
                // エスカレ回答テーブルから入力した管理番号存在チェック
                dtEscalationResponse = dao.select_T_ESCALATION_RESPONSE();
                _logger.Info("エスカレ回答テーブル取得数 [" + dtEscalationResponse.Rows.Count + "]");

                if (dtEscalationResponse.Rows.Count <= 0)
                {
                    _logger.Info("エスカレ回答テーブルに該当データが存在しません。");
                }
                else
                {
                    comboResponse.DataSource = dtEscalationResponse;
                    comboResponse.DisplayMember = "RESPONSE_TEXT";
                    comboResponse.ValueMember = "RESPONSE_CODE";
                }
            }
            catch (Exception ex)
            {
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エスカレ回答登録", MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region エスカレ回答登録ボタン押下
        private void btnTempResponseRegistClick(object sender, EventArgs e)
        {

            _logger.Info("エスカレ回答登録：エスカレ回答登録ボタン押下");

            // ｢エスカレテーブル｣｢MS返却フラグ」＝1 で「エスカレ回答」プルダウンが「契約者返却」の場合
            if ( dtEscalation.Rows[0]["MS_RETURN_FLAG"].ToString() == "1" && comboResponse.SelectedValue.ToString() != "2")
            {
                new clsMessageBox().MessageBoxOKOnly("MS返却対象のものです、確認してください。", "エスカレ回答登録", MessageBoxIcon.Error);
                comboResponse.Focus();
                return;
            }

            try
            {
                tmtRegistCnt++;
                // 回答_TEMPテーブルデータ登録
                dao.insert_T_RESPONSE_TMP(dtEscalation, tmtRegistCnt, comboResponse.SelectedValue.ToString());

                // DataGridViewバインド処理
                dataGridView_Response_List_Binding();
            }
            catch (Exception ex)
            {
                _logger.Info("回答_TEMPテーブルの登録処理でエラーが発生しました。" + ex.ToString());
                new clsMessageBox().MessageBoxOKOnly("回答_TEMPテーブルの登録処理でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "私物登録", MessageBoxIcon.Error);
                return;
            }

            Label_Finish_Record_Num.Text = tmtRegistCnt.ToString("D3") + " 件";

            // 入力欄初期化
            inputMenuDefualtDisplay();
        }
        #endregion

        #region 回答登録一覧Gridviewバインド        
        private void dataGridView_Response_List_Binding()
        {           

            try
            {
                // 回答_TEMPテーブルからデータを取得し、Gridviewにバインド
                using (var dao = new daofrmMSPB002("DBConnection", _userName))
                {
                    dtResponseTmp = dao.select_T_RESPONSE_TMP();
                }
                _logger.Info("回答_TEMP取得数 [" + dtResponseTmp.Rows.Count + "]");
            }
            catch (Exception ex)
            {
                _logger.Info("回答_TEMPテーブルのデータ取得でエラーが発生しました。" + ex.ToString());
                new clsMessageBox().MessageBoxOKOnly("回答_TEMPテーブルのデータ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "ユーザ管理エクスポート", MessageBoxIcon.Warning);
                return;
            }

            if (dtResponseTmp.Rows.Count <= 0 || dtResponseTmp == null)
            {
                _logger.Info("回答_TEMPテーブルにデータが存在しません。");
                dtos.Clear();
                dataGridView_Regist_List.DataSource = null;
            }
            else
            {
                dtos.Clear();
                dataGridView_Regist_List.DataSource = null;

                for (int i = 0; i < dtResponseTmp.Rows.Count; i++)
                {
                    // 回答_TEMPテーブルに登録したデータを回答登録一覧にバインド
                    ResponseTMPEntity dto = new ResponseTMPEntity();
                    dto.ID = int.Parse(dtResponseTmp.Rows[i]["ID"].ToString());

                    // 登録日の形式「yyyyMMdd」を「yyyy/MM/dd」に変換して「登録日」項目にセット
                    DateTime dateTime = DateTime.ParseExact(dtResponseTmp.Rows[i]["REPORT_DATE"].ToString(), "yyyyMMdd", null);
                    dto.REPORT_DATE = dateTime.ToString("yyyy/MM/dd");
                    dto.PRODUCT_TYPE = dtResponseTmp.Rows[i]["PRODUCT_TYPE"].ToString();
                    dto.CONTROL_NO = dtResponseTmp.Rows[i]["CONTROL_NO"].ToString();
                    dto.CONTRACT_NO = dtResponseTmp.Rows[i]["CONTRACT_NO"].ToString();
                    
                    // 回答_TEMPの「ESCALATION_RESPONSE」値に対するエスカレ回答テーブルの「RESPONSE_TEXT」取得して「エスカレ回答」項目にセット
                    string displayName = dtEscalationResponse.AsEnumerable()
                                         .Where(row => (string)row["RESPONSE_CODE"] == dtResponseTmp.Rows[i]["ESCALATION_RESPONSE"].ToString())
                                         .Select(row => (string)row["RESPONSE_TEXT"])
                                         .FirstOrDefault();
                    dto.ESCALATION_RESPONSE = displayName;

                    dtos.Add(dto);
                }
                //担当者のリストをDataGridViewにデータバインドする
                dataGridView_Regist_List.DataSource = dtos;

                //データグリッドのタイトル設定
                dataGridView_Regist_List.Columns[0].HeaderText = "ID";
                dataGridView_Regist_List.Columns[1].HeaderText = "登録日";
                dataGridView_Regist_List.Columns[2].HeaderText = "種別";
                dataGridView_Regist_List.Columns[3].HeaderText = "管理番号";
                dataGridView_Regist_List.Columns[4].HeaderText = "証券番号";
                dataGridView_Regist_List.Columns[5].HeaderText = "エスカレ回答";

                //更新禁止
                dataGridView_Regist_List.Columns[0].ReadOnly = true;
                dataGridView_Regist_List.Columns[1].ReadOnly = true;
                dataGridView_Regist_List.Columns[2].ReadOnly = true;
                dataGridView_Regist_List.Columns[3].ReadOnly = true;
                dataGridView_Regist_List.Columns[4].ReadOnly = true;
                dataGridView_Regist_List.Columns[5].ReadOnly = true;

                //初期表示の選択されているセルをなくす
                dataGridView_Regist_List.CurrentCell = null;

                //ヘッダテキストの文字列の折り返しを抑止
                dataGridView_Regist_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                //ヘッダテキストの文字配置はセル内センター
                dataGridView_Regist_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
                foreach (DataGridViewColumn c in dataGridView_Regist_List.Columns)
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;

                //列の自動設定を抑止
                dataGridView_Regist_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                //各列の幅を設定
                dataGridView_Regist_List.Columns[0].Width = 45;
                dataGridView_Regist_List.Columns[1].Width = 100;
                dataGridView_Regist_List.Columns[2].Width = 110;
                dataGridView_Regist_List.Columns[3].Width = 170;
                dataGridView_Regist_List.Columns[4].Width = 190;
                dataGridView_Regist_List.Columns[5].Width = 112;

                //文字サイスを設定
                dataGridView_Regist_List.Font = new Font("メイリオ", 9F);

                //列のセルのテキストの配置を上下左右とも中央にする
                dataGridView_Regist_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Regist_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Regist_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Regist_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Regist_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Regist_List.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 選択モードを行単位での選択のみにする
                dataGridView_Regist_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //DataGridViewでセル、行、列が複数選択できないようにする
                dataGridView_Regist_List.MultiSelect = false;

            }
        }
        #endregion

        #endregion
    }
}
