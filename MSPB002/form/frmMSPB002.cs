using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
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
        private System.Windows.Forms.TextBox txtRegistDate;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.TextBox txtContractNo;
        private System.Windows.Forms.TextBox txtPBContents;
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
        private System.Windows.Forms.TextBox txtInputRegistDate;
        private System.Windows.Forms.TextBox txtInputControlNo;
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
            this.txtInputControlNo = new System.Windows.Forms.TextBox();
            this.txtRegistDate = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.txtPBContents = new System.Windows.Forms.TextBox();
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
            this.txtInputRegistDate = new System.Windows.Forms.TextBox();
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
            this.Btn_Cancel.Location = new System.Drawing.Point(22, 686);
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
            this.Btn_Register.Location = new System.Drawing.Point(625, 686);
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
            this.tableLayoutPanel1.Controls.Add(this.txtInputControlNo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 211);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 57);
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
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "管理番号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInputControlNo
            // 
            this.txtInputControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputControlNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtInputControlNo.Location = new System.Drawing.Point(4, 29);
            this.txtInputControlNo.MaxLength = 20;
            this.txtInputControlNo.Name = "txtInputControlNo";
            this.txtInputControlNo.Size = new System.Drawing.Size(178, 25);
            this.txtInputControlNo.TabIndex = 2;
            this.txtInputControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CONTROL_NO_KeyDown);
            // 
            // txtRegistDate
            // 
            this.txtRegistDate.BackColor = System.Drawing.Color.White;
            this.txtRegistDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegistDate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRegistDate.Location = new System.Drawing.Point(4, 33);
            this.txtRegistDate.Name = "txtRegistDate";
            this.txtRegistDate.ReadOnly = true;
            this.txtRegistDate.Size = new System.Drawing.Size(85, 18);
            this.txtRegistDate.TabIndex = 5;
            this.txtRegistDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductType
            // 
            this.txtProductType.BackColor = System.Drawing.Color.White;
            this.txtProductType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductType.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtProductType.Location = new System.Drawing.Point(96, 33);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(97, 18);
            this.txtProductType.TabIndex = 6;
            this.txtProductType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtControlNo
            // 
            this.txtControlNo.BackColor = System.Drawing.Color.White;
            this.txtControlNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtControlNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtControlNo.Location = new System.Drawing.Point(200, 33);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(156, 18);
            this.txtControlNo.TabIndex = 7;
            this.txtControlNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractNo
            // 
            this.txtContractNo.BackColor = System.Drawing.Color.White;
            this.txtContractNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContractNo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtContractNo.Location = new System.Drawing.Point(363, 33);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.ReadOnly = true;
            this.txtContractNo.Size = new System.Drawing.Size(170, 18);
            this.txtContractNo.TabIndex = 8;
            this.txtContractNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPBContents
            // 
            this.txtPBContents.BackColor = System.Drawing.Color.White;
            this.txtPBContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPBContents.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPBContents.Location = new System.Drawing.Point(540, 33);
            this.txtPBContents.Name = "txtPBContents";
            this.txtPBContents.ReadOnly = true;
            this.txtPBContents.Size = new System.Drawing.Size(140, 18);
            this.txtPBContents.TabIndex = 9;
            this.txtPBContents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 636F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtRegistDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtProductType, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtControlNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtContractNo, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPBContents, 4, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(34, 313);
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
            this.dataGridView_Regist_List.Location = new System.Drawing.Point(6, 451);
            this.dataGridView_Regist_List.Name = "dataGridView_Regist_List";
            this.dataGridView_Regist_List.ReadOnly = true;
            this.dataGridView_Regist_List.RowHeadersVisible = false;
            this.dataGridView_Regist_List.RowTemplate.Height = 21;
            this.dataGridView_Regist_List.Size = new System.Drawing.Size(747, 216);
            this.dataGridView_Regist_List.TabIndex = 10;
            // 
            // Label_Finish_Record_Num
            // 
            this.Label_Finish_Record_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Finish_Record_Num.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_Finish_Record_Num.Location = new System.Drawing.Point(581, 419);
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
            this.btnReLoad.Location = new System.Drawing.Point(586, 226);
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
            this.panelTitle.Location = new System.Drawing.Point(15, 4);
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
            // txtInputRegistDate
            // 
            this.txtInputRegistDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtInputRegistDate.Location = new System.Drawing.Point(23, 145);
            this.txtInputRegistDate.MaxLength = 8;
            this.txtInputRegistDate.Name = "txtInputRegistDate";
            this.txtInputRegistDate.Size = new System.Drawing.Size(114, 31);
            this.txtInputRegistDate.TabIndex = 1;
            this.txtInputRegistDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputRegistDateCheck);
            this.txtInputRegistDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressRegistDateCheck);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(429, 226);
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
            this.CMT_Shipping.Location = new System.Drawing.Point(304, 388);
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
            this.comboResponse.Location = new System.Drawing.Point(413, 384);
            this.comboResponse.Name = "comboResponse";
            this.comboResponse.Size = new System.Drawing.Size(145, 32);
            this.comboResponse.TabIndex = 5;
            // 
            // frmMSPB002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(757, 733);
            this.Controls.Add(this.comboResponse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtInputRegistDate);
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
            _logger.Info("私物返却管理DB：エスカレ回答登録 開始");
            _userName = userName;
            dao = new daofrmMSPB002("DBConnection", _userName);

            InitializeComponent();

            this.ActiveControl = this.txtInputControlNo;

            // 登録日初期化
            txtInputRegistDate.Text = System.DateTime.Now.ToString("yyyyMMdd");

            // TEMPテーブル削除
            deleteResponseTMPTable();

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
            _logger.Info("管理番号検索 : 開始");
            // 検索結果にデータがあった場合
            if (txtRegistDate.Text != "" || txtProductType.Text != "" || txtControlNo.Text != "" || txtContractNo.Text != "" || txtPBContents.Text != "")
            {
                _logger.Info("管理番号検索 : 検索結果存在有");
                DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録一覧に回答登録していません、\r\n登録しますか？", "警告", MessageBoxIcon.Warning);
                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    // 入力した管理番号保持
                    var text = txtInputControlNo.Text;

                    _logger.Info("管理番号検索 : 検索結果存在有_回答TEMP登録");
                    _logger.Info("管理番号検索 : 終了");
                    // 「エスカレ回答登録」ボタン押下処理                    
                    btnTempResponseRegistClick(sender, e);

                    // 保持した管理番号セット
                    txtInputControlNo.Text = text;

                    return;
                }
                else
                {
                    _logger.Info("管理番号検索 : 検索結果存在有_既存検索結果クリア");                    
                    // 「いいえ」の場合、検索結果をクリアして後続処理を行う
                    txtRegistDate.Text = "";
                    txtProductType.Text = "";
                    txtControlNo.Text = "";
                    txtContractNo.Text = "";
                    txtPBContents.Text = "";

                    return;
                }

            }

            // 入力した管理番号の桁数チェック
            if (txtInputControlNo.Text.Length != 20)
            {
                _logger.Info("管理番号検索 : 終了（管理番号桁数違い）");
                new clsMessageBox().MessageBoxOKOnly("桁数が異なります、\r\n読込直してください。", "警告", MessageBoxIcon.Warning);
                inputMenuDefualtDisplay();
                return;
            }

            _logger.Debug($"入力した管理番号（{txtInputControlNo.Text}）");

            try
            {
                // 回答_TEMPテーブルから入力した管理番号存在チェック
                var dtTemp = dao.Select_T_RESPONSE_TMP(txtInputControlNo.Text);
                _logger.Debug("回答_TEMPテーブル取得数 [" + dtTemp.Rows.Count + "]");

                if (dtTemp.Rows.Count <= 0)
                {
                    // エスカレテーブルから入力した管理番号存在チェック
                    dtEscalation = dao.Select_T_ESCALATION(txtInputControlNo.Text);
                    _logger.Debug("エスカレテーブル取得数 [" + dtEscalation.Rows.Count + "]");

                    if (dtEscalation.Rows.Count <= 0)
                    {
                        new clsMessageBox().MessageBoxOKOnly("エスカレ報告が存在しません。", "警告", MessageBoxIcon.Warning);
                        inputMenuDefualtDisplay();
                        return;
                    }
                    else
                    {
                        // 取得したデータのステータスが「6：返却済」の場合
                        if (dtEscalation.Rows[0]["STATUS"].ToString() == "6")
                        {
                            new clsMessageBox().MessageBoxOKOnly("返却済です。", "警告", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }
                        // 取得したデータのステータスが「2：回答済」の場合
                        else if (dtEscalation.Rows[0]["STATUS"].ToString() == "2")
                        {
                            DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録済です、\r\n回答内容を変更しますか？", "警告", MessageBoxIcon.Warning);
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
                            new clsMessageBox().MessageBoxOKOnly("承認済です。", "警告", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }
                        // 取得したデータのステータスが「5：返却処理」の場合
                        else if (dtEscalation.Rows[0]["STATUS"].ToString() == "5")
                        {
                            new clsMessageBox().MessageBoxOKOnly("返却処理中です。", "警告", MessageBoxIcon.Warning);
                            inputMenuDefualtDisplay();
                            return;
                        }

                        txtRegistDate.Text = dtEscalation.Rows[0]["REGIST_DATE"].ToString();
                        txtProductType.Text = dtEscalation.Rows[0]["PRODUCT_TYPE"].ToString();
                        txtControlNo.Text = dtEscalation.Rows[0]["CONTROL_NO"].ToString();
                        txtContractNo.Text = dtEscalation.Rows[0]["CONTRACT_NO"].ToString();
                        txtPBContents.Text = dtEscalation.Rows[0]["PERSONAL_BELONGINGS_INFO"].ToString();
                    }
                }
                else
                {
                    _logger.Debug($"入力した管理番号（{txtInputControlNo.Text}）は回答登録一覧と重複しています、回答登録済｡");
                    _logger.Info("管理番号検索 : 終了（回答登録済）");
                    new clsMessageBox().MessageBoxOKOnly("回答登録一覧と重複しています、\r\n回答登録済｡", "警告", MessageBoxIcon.Warning);
                    inputMenuDefualtDisplay();
                    return;
                }

            }
            catch (Exception ex)
            {
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
            _logger.Info("管理番号検索 : 終了");
        }
        #endregion

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答登録：戻るボタン押下");

            // 「検索結果」または「回答登録一覧」にデータが存在した場合。
            if (txtRegistDate.Text != "" || 
                txtProductType.Text != "" || 
                txtControlNo.Text != "" || 
                txtContractNo.Text != "" || 
                txtPBContents.Text != "" ||
                dataGridView_Regist_List.Rows.Count > 0)
            {
                DialogResult result = new clsMessageBox().MessageBoxYesNo("回答登録をしていません、\r\n登録を中止・一覧を削除しますか？", "警告", MessageBoxIcon.Warning);
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
                            dao.Delete_T_RESPONSE_TMP();

                            // コミット
                            dao.Commit();
                        }
                        catch (Exception ex)
                        {
                            // ロールバック
                            dao.Rollback();
                            new clsMessageBox().MessageBoxOKOnly("回答_TEMPデータ削除でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _logger.Info("私物返却管理DB：エスカレ回答登録 終了");
                    this.Close();                    
                }
                else
                {
                    txtInputControlNo.Focus();
                    return;
                }
            }
            else
            {
                _logger.Info("私物返却管理DB：エスカレ回答登録 終了");
                this.Close();
            }            
        }
        #endregion

        #region 管理番号入力欄エンターキー処理
        private void textBox_CONTROL_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 登録日欄非活性
                txtInputRegistDate.Enabled = false;

                btnSearchClick(sender, e);
            }
        }
        #endregion

        #region 登録日入力制限（数値のみ）＆日付形式チェック
        private void inputRegistDateCheck(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!DateTime.TryParseExact(txtInputRegistDate.Text, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var d))
                {
                    new clsMessageBox().MessageBoxOKOnly("登録日の形式が異なります、\r\n日付を確認してください。", "警告", MessageBoxIcon.Warning);
                    txtInputRegistDate.Focus();
                    return;
                }
                else
                {
                    txtInputControlNo.Focus();
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

        #region エスカレ回答登録ボタン押下
        private void btnTempResponseRegistClick(object sender, EventArgs e)
        {
            if (txtRegistDate.Text != "")
            {
                _logger.Debug("エスカレ回答登録：エスカレ回答登録ボタン押下");
                _logger.Info("回答TEMP_登録処理 : 開始");

                // ｢エスカレテーブル｣｢MS返却フラグ」＝1 で「エスカレ回答」プルダウンが「契約者返却」の場合
                if (dtEscalation.Rows[0]["MS_RETURN_FLAG"].ToString() == "1" && comboResponse.SelectedValue.ToString() != "2")
                {
                    new clsMessageBox().MessageBoxOKOnly("MS返却対象のものです、\r\n確認してください。", "エラー", MessageBoxIcon.Error);
                    comboResponse.Focus();
                    return;
                }

                try
                {
                    tmtRegistCnt++;
                    // 回答_TEMPテーブルデータ登録
                    dao.Insert_T_RESPONSE_TMP(dtEscalation, tmtRegistCnt, comboResponse.SelectedValue.ToString());

                    // DataGridViewバインド処理
                    dataGridView_Response_List_Binding();


                    int rowNo = 0;

                    // 更新した行を選択
                    foreach (DataGridViewRow row in dataGridView_Regist_List.Rows)
                    {
                        if (row.Cells[3].Value.ToString() == dtEscalation.Rows[0]["CONTROL_NO"].ToString())
                        {
                            if (rowNo < 5)
                            {
                                dataGridView_Regist_List.FirstDisplayedScrollingRowIndex = 0;
                                dataGridView_Regist_List.Rows[rowNo].Selected = true;
                            }
                            else
                            {
                                dataGridView_Regist_List.FirstDisplayedScrollingRowIndex = rowNo - 4;
                                dataGridView_Regist_List.Rows[rowNo].Selected = true;
                            }
                            break;
                        }
                        rowNo++;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Info("回答_TEMPテーブルの登録処理でエラーが発生しました。" + ex.ToString());
                    _logger.Info("回答TEMP_登録処理 : 終了");
                    new clsMessageBox().MessageBoxOKOnly("回答_TEMPテーブルの登録処理でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                    return;
                }

                Label_Finish_Record_Num.Text = tmtRegistCnt.ToString("D3") + " 件";

                _logger.Info("回答TEMP_登録処理 : 終了");

                // 入力欄初期化
                inputMenuDefualtDisplay();
            }

        }
        #endregion

        #region 回答登録ボタン押下
        private void btnRegistClick(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答登録：回答登録ボタン押下");
            _logger.Info("回答登録処理 : 開始");

            // 検索結果にデータが存在した場合
            if (txtRegistDate.Text != "" ||
                txtProductType.Text != "" ||
                txtControlNo.Text != "" ||
                txtContractNo.Text != "" ||
                txtPBContents.Text != "")
            {
                _logger.Info("回答登録処理 : 検索結果存在有");

                DialogResult result = new clsMessageBox().MessageBoxYesNo("回収登録一覧に登録していません、\r\n登録しますか？", "警告", MessageBoxIcon.Warning);
                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    _logger.Info("回答登録処理 : 検索結果存在有_回答TEMP登録");
                    _logger.Info("回答登録処理 : 終了");
                    // エスカレ回答登録ボタン押下処理
                    btnTempResponseRegistClick(sender, e);
                    return;
                }
                else
                {
                    _logger.Info("回答登録処理 : 検索結果存在有_既存検索結果クリア");
                    _logger.Info("回答登録処理 : 終了");
                    // 検索結果クリア
                    inputMenuDefualtDisplay();
                    return;
                }
            }

            DialogResult result1 = new clsMessageBox().MessageBoxYesNo("エスカレ回答を登録します、\r\nよろしいですか？", "警告", MessageBoxIcon.Warning);
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
                        dao.Update_T_ESCALATION(updateStatus, txtInputRegistDate.Text, row["CONTROL_NO"].ToString(), _userName, row["ESCALATION_RESPONSE"].ToString());
                    }

                    // 回答_TEMPテーブルデータ削除処理
                    dao.Delete_T_RESPONSE_TMP();

                    // コミット
                    dao.Commit();

                }
                catch (Exception ex)
                {
                    // ロールバック
                    dao.Rollback();
                    _logger.Info("エスカレ回答登録処理でエラーが発生しました。" + ex.ToString());
                    _logger.Info("回答登録処理 : 終了");
                    new clsMessageBox().MessageBoxOKOnly("エスカレ回答登録処理でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
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
                txtInputControlNo.Focus();
                _logger.Info("回答登録処理 : 終了");
                return;
            }

            // 登録日初期化
            txtInputRegistDate.Text = System.DateTime.Now.ToString("yyyyMMdd");
            txtInputRegistDate.Enabled = true;

            _logger.Info("回答登録処理 : 終了");
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
            //txtInputRegistDate.Text = System.DateTime.Now.ToString("yyyyMMdd");
            txtInputControlNo.Text = "";
            txtInputControlNo.Focus();

            comboResponse.SelectedIndex = 0;

            txtRegistDate.Text = "";
            txtProductType.Text = "";
            txtControlNo.Text = "";
            txtContractNo.Text = "";
            txtPBContents.Text = "";

            Label_Finish_Record_Num.Text = tmtRegistCnt.ToString("D3") + " 件";

        }
        #endregion

        #region エスカレ回答プルダウン設定
        private void setEscalationReponse()
        {
            try
            {
                // エスカレ回答テーブルから入力した管理番号存在チェック
                dtEscalationResponse = dao.Select_T_ESCALATION_RESPONSE();
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
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
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
                    dtResponseTmp = dao.Select_T_RESPONSE_TMP();
                }
                _logger.Info("回答_TEMP取得数 [" + dtResponseTmp.Rows.Count + "]");
            }
            catch (Exception ex)
            {
                _logger.Info("回答_TEMPテーブルのデータ取得でエラーが発生しました。" + ex.ToString());
                new clsMessageBox().MessageBoxOKOnly("回答_TEMPテーブルのデータ取得でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Warning);
                return;
            }

            if (dtResponseTmp.Rows.Count <= 0 || dtResponseTmp == null)
            {
                _logger.Info("回答_TEMPテーブルにデータが存在しません。");
                dtos.Clear();
                dataGridView_Regist_List.DataSource = null;
            }
            
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
        #endregion

        #region 回答_TMPテーブル削除
        private void deleteResponseTMPTable()
        {            
            try
            {
                // トランザクション開始
                dao.BeginTransaction();

                // 回答_TEMPテーブルデータ削除
                dao.Delete_T_RESPONSE_TMP();

                // コミット
                dao.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック
                dao.Rollback();
                new clsMessageBox().MessageBoxOKOnly("回答_TEMPデータ削除でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }            
        }
        #endregion

        #endregion
    }
}
