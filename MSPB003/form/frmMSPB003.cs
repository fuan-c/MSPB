﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using log4net;
using MSPB.Common;
using MSPB.MSPB003.dao;
using MSPB.MSPB003.logic;
using MSPB.MSPB003.pdf;
using System.Data;
using System.IO;
using MSPB.MSPB003.common;
using System.Globalization;

namespace MSPB.MSPB003.form
{

    /// <summary>
    /// 発送帳票出力画面
    /// </summary>
    class frmMSPB003 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMSRTNCnt;
        private System.Windows.Forms.Label lblMSRTNOverCnt;
        private System.Windows.Forms.Label lblNonApprovedCnt;
        private System.Windows.Forms.Label lblTrackingNoRemain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblContractRTNCnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateShippingDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkRegistDate;
        private System.Windows.Forms.Panel panel1;
        private Label lblHiddenShippingDate;
        private System.Windows.Forms.Button btnSlipPrint;


        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {            
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMSRTNCnt = new System.Windows.Forms.Label();
            this.lblMSRTNOverCnt = new System.Windows.Forms.Label();
            this.lblNonApprovedCnt = new System.Windows.Forms.Label();
            this.lblTrackingNoRemain = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblContractRTNCnt = new System.Windows.Forms.Label();
            this.btnSlipPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateShippingDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkRegistDate = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHiddenShippingDate = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(729, 100);
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
            this.header0.Location = new System.Drawing.Point(228, 14);
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
            this.header1.Location = new System.Drawing.Point(274, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(159, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "発送帳票出力";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(72, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "顧客返却";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(229, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "MS返却";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(386, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "MS返却 (超過)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(547, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "未承認";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "件数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMSRTNCnt
            // 
            this.lblMSRTNCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMSRTNCnt.BackColor = System.Drawing.Color.White;
            this.lblMSRTNCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMSRTNCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMSRTNCnt.Location = new System.Drawing.Point(229, 34);
            this.lblMSRTNCnt.Name = "lblMSRTNCnt";
            this.lblMSRTNCnt.Size = new System.Drawing.Size(151, 31);
            this.lblMSRTNCnt.TabIndex = 0;
            this.lblMSRTNCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMSRTNOverCnt
            // 
            this.lblMSRTNOverCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMSRTNOverCnt.BackColor = System.Drawing.Color.White;
            this.lblMSRTNOverCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMSRTNOverCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMSRTNOverCnt.Location = new System.Drawing.Point(386, 34);
            this.lblMSRTNOverCnt.Name = "lblMSRTNOverCnt";
            this.lblMSRTNOverCnt.Size = new System.Drawing.Size(151, 31);
            this.lblMSRTNOverCnt.TabIndex = 0;
            this.lblMSRTNOverCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNonApprovedCnt
            // 
            this.lblNonApprovedCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNonApprovedCnt.BackColor = System.Drawing.Color.White;
            this.lblNonApprovedCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNonApprovedCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNonApprovedCnt.Location = new System.Drawing.Point(543, 34);
            this.lblNonApprovedCnt.Name = "lblNonApprovedCnt";
            this.lblNonApprovedCnt.Size = new System.Drawing.Size(151, 31);
            this.lblNonApprovedCnt.TabIndex = 0;
            this.lblNonApprovedCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrackingNoRemain
            // 
            this.lblTrackingNoRemain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTrackingNoRemain.BackColor = System.Drawing.SystemColors.Window;
            this.lblTrackingNoRemain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrackingNoRemain.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTrackingNoRemain.Location = new System.Drawing.Point(66, 42);
            this.lblTrackingNoRemain.Name = "lblTrackingNoRemain";
            this.lblTrackingNoRemain.Size = new System.Drawing.Size(164, 31);
            this.lblTrackingNoRemain.TabIndex = 1;
            this.lblTrackingNoRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.Controls.Add(this.lblContractRTNCnt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMSRTNCnt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMSRTNOverCnt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNonApprovedCnt, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 147);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 69);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblContractRTNCnt
            // 
            this.lblContractRTNCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContractRTNCnt.BackColor = System.Drawing.Color.White;
            this.lblContractRTNCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContractRTNCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractRTNCnt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblContractRTNCnt.Location = new System.Drawing.Point(72, 34);
            this.lblContractRTNCnt.Name = "lblContractRTNCnt";
            this.lblContractRTNCnt.Size = new System.Drawing.Size(151, 31);
            this.lblContractRTNCnt.TabIndex = 0;
            this.lblContractRTNCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSlipPrint
            // 
            this.btnSlipPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSlipPrint.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSlipPrint.Location = new System.Drawing.Point(548, 130);
            this.btnSlipPrint.Name = "btnSlipPrint";
            this.btnSlipPrint.Size = new System.Drawing.Size(143, 31);
            this.btnSlipPrint.TabIndex = 4;
            this.btnSlipPrint.Text = "帳票出力";
            this.btnSlipPrint.UseVisualStyleBackColor = true;
            this.btnSlipPrint.Click += new System.EventHandler(this.btnSlipPrintClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(63, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "ゆうパック追跡番号残数";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(63, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "出荷指定日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateShippingDate
            // 
            this.dateShippingDate.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateShippingDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateShippingDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateShippingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateShippingDate.Location = new System.Drawing.Point(66, 130);
            this.dateShippingDate.Name = "dateShippingDate";
            this.dateShippingDate.Size = new System.Drawing.Size(141, 31);
            this.dateShippingDate.TabIndex = 2;
            this.dateShippingDate.Value = new System.DateTime(2020, 10, 5, 0, 0, 0, 0);
            this.dateShippingDate.CloseUp += new System.EventHandler(this.dateShippingDateClosdUp);
            this.dateShippingDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateShippingDateKeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(558, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // checkRegistDate
            // 
            this.checkRegistDate.AutoSize = true;
            this.checkRegistDate.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkRegistDate.Location = new System.Drawing.Point(66, 168);
            this.checkRegistDate.Name = "checkRegistDate";
            this.checkRegistDate.Size = new System.Drawing.Size(309, 25);
            this.checkRegistDate.TabIndex = 3;
            this.checkRegistDate.Text = "出荷指定日の確認後にチェックして下さい。";
            this.checkRegistDate.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHiddenShippingDate);
            this.panel1.Controls.Add(this.checkRegistDate);
            this.panel1.Controls.Add(this.dateShippingDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSlipPrint);
            this.panel1.Controls.Add(this.lblTrackingNoRemain);
            this.panel1.Location = new System.Drawing.Point(10, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 221);
            this.panel1.TabIndex = 0;
            // 
            // lblHiddenShippingDate
            // 
            this.lblHiddenShippingDate.Location = new System.Drawing.Point(242, 130);
            this.lblHiddenShippingDate.Name = "lblHiddenShippingDate";
            this.lblHiddenShippingDate.Size = new System.Drawing.Size(79, 13);
            this.lblHiddenShippingDate.TabIndex = 6;
            this.lblHiddenShippingDate.Text = "label";
            this.lblHiddenShippingDate.Visible = false;
            // 
            // frmMSPB003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB003";
            this.Text = "MS 私物返却管理DB 発送帳票出力";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private static string _userName = string.Empty;
        /// <summary>
        /// 出荷指定日初期表示加算日数
        /// </summary>
        public int SHIPPING_DATE_ADD_DAYS = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MSPB003_SHIPPING_DATE_ADD_DAYS"]);
        /// <summary>
        /// 出荷指定日チェック加算日数
        /// </summary>
        public int SHIPPING_DATE_LIMIT_ADD_DAYS = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MSPB003_SHIPPING_DATE_LIMIT_ADD_DAYS"]);
        /// <summary>
        /// 会社情報
        /// </summary>
        private clsCompany CompanyInfo;

        daofrmMSPB003 dao = null;
        
        DataTable dtContract = new DataTable();
        DataTable dtMSRtn = new DataTable();
        DataTable dtMSRtnOver = new DataTable();
        DataTable dtTrackingNo = null;

        private readonly DateTime now = DateTime.Now;

        private bool rtnTrgMessageFlg = true;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB003(string userName)
        {
            _logger.Info("私物返却管理DB：発送帳票出力 開始");

            _userName = userName;
            dao = new daofrmMSPB003("DBConnection");

            InitializeComponent();

            this.ActiveControl = this.btnSlipPrint;
            
            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            this.Shown += frmMSPB003_Shown;
            
        }
        #endregion

        #region イベント

        #region Shown処理
        private void frmMSPB003_Shown(object sender, EventArgs e)
        {
            // 出荷日指定日付設定（システム日付＋1、土日は除く）
            setShiplingDate();

            // 画面上の発送帳票出力対象件数設定
            setSendSlipTargeCntDisplay();
                       
        }
        #endregion

        #region 変更したた出荷指定日チェック
        private void dateShippingDateClosdUp(object sender, EventArgs e)
        {
            if (string.Compare(dateShippingDate.Value.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd")) == -1
                || string.Compare(dateShippingDate.Value.ToString("yyyyMMdd"), DateTime.Now.AddDays(5).ToString("yyyyMMdd")) == 1)
            {
                if (new clsMessageBox().MessageBoxYesNo("出荷日が範囲外です。よろしいですか？", "確認", MessageBoxIcon.Question) == DialogResult.No)
                {
                    dateShippingDate.Value = DateTime.Parse(lblHiddenShippingDate.Text);
                }
            }
            lblHiddenShippingDate.Text = dateShippingDate.Value.ToString("yyyy/MM/dd");
        }

        private void dateShippingDateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 出荷指定日チェック処理呼び出し
                dateShippingDateClosdUp(sender, e);
            }
        }
        #endregion

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("発送帳票出力：戻るボタン押下");
            _logger.Info("私物返却管理DB：発送帳票出力 終了");
            this.Close();
        }
        #endregion

        #region 伝票出力ボタン押下
        private void btnSlipPrintClick(object sender, EventArgs e)
        {
            _logger.Debug("発送伝票出力：伝票出力ボタン押下");
            _logger.Info("伝票出力処理：開始");

            //出荷日指定チェックボックス確認
            if (!this.checkRegistDate.Checked)
            {
                _logger.Debug("出荷指定日を確認して下さい。");
                new clsMessageBox().MessageBoxOKOnly("出荷指定日を確認してください。", "警告", MessageBoxIcon.Warning);
                return;
            }

            //追跡番号チェック
            if (int.Parse(this.lblTrackingNoRemain.Text, NumberStyles.AllowThousands) < int.Parse(this.lblContractRTNCnt.Text, NumberStyles.AllowThousands))            
            {
                _logger.Debug("追跡番号を作成してください。");
                new clsMessageBox().MessageBoxOKOnly("追跡番号を作成してください。", "警告", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 梱包ラインテーブルにて出荷日指定の日付存在チェック
                DataTable shippingDateChk = dao.Select_ShippingDateCheck_T_MS_PACKING_LINE(dateShippingDate.Value.ToString("yyyyMMdd"));
                _logger.Info("梱包ラインテーブルの出荷日件数 [" + shippingDateChk.Rows.Count + "]");

                if (shippingDateChk.Rows.Count > 0)
                {
                    _logger.Info("指定した出荷日は梱包ラインテーブルに登録済みです。");
                    _logger.Info("出荷日指定の日付存在チェック：終了");
                    new clsMessageBox().MessageBoxOKOnly("指定した出荷日は登録済みです。", "警告", MessageBoxIcon.Warning);
                    return;
                }                
            }
            catch (Exception ex)
            {
                _logger.Fatal("テーブルから対象データ取得でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
            finally
            {
                _logger.Info("出荷日指定の日付存在チェック：終了");
            }
            

            try
            {

                // トランザクション開始
                dao.BeginTransaction();

                // MS発送_QMSテーブル登録処理
                registMSShippingQMS();

                // 各種帳票出力処理
                outputShippingSlip();

                // コミット
                dao.Commit();
                
            }
            catch{
                // ロールバック
                dao.Rollback();
            }
            finally
            {
                _logger.Info("伝票出力処理：終了");
            }            
        }
        #endregion

        #endregion

        #region メソッド

        #region 発送帳票出力対象件数設定
        private void setSendSlipTargeCntDisplay()
        {
            _logger.Info("承認対象件数取得処理：開始");
                        
            try
            {   
                
                // エスカレテーブルより承認のデータ取得
                DataTable dtApproved = dao.Select_Approved_T_ESCALATION();
                _logger.Info("エスカレテーブル承認データ取得数 [" + dtApproved.Rows.Count + "]");

                // エスカレテーブルより未承認の件数取得
                DataTable dtNonApproved = dao.Select_NonApprovedCnt_T_ESCALATION(now);                
                _logger.Info("エスカレテーブル未承認件数 [" + dtNonApproved.Rows.Count + "]");

                // MSゆう追跡番号テーブルより追跡番号残数取得
                dtTrackingNo = dao.Select_TrackingNoCnt_T_MS_YUU_TRACKING_NUMBER();                
                _logger.Info("MSゆう追跡番号テーブル追跡番号残数 [" + dtTrackingNo.Rows.Count + "]");

                if (dtApproved.Rows.Count <= 0 && dtNonApproved.Rows.Count <= 0)
                {
                    _logger.Info("エスカレテーブルに該当承認データが存在しません。");

                    dtContract.Clear();
                    dtMSRtn.Clear();
                    dtMSRtnOver.Clear();
                    dtNonApproved.Clear();

                }
                else
                {
                    // 契約者返却件数取得
                    var contractRows = dtApproved.AsEnumerable()
                                         .Where(row => (string)row["STATUS"] == "3").Where(row => (string)row["ESCALATION_RESPONSE"] == "1").OrderBy(row => row["ID"]);
                    
                    if (contractRows.Count() > 0)
                    {
                        dtContract = contractRows.CopyToDataTable();
                    }

                    // MS返却件数取得
                    var msRtnRows = dtApproved.AsEnumerable()
                                         .Where(row => (string)row["STATUS"] == "3").Where(row => (string)row["ESCALATION_RESPONSE"] == "2").OrderBy(row => row["ID"]);

                    if (msRtnRows.Count() > 0)
                    {
                        dtMSRtn = msRtnRows.CopyToDataTable();
                    }

                    // MS返却(超過)件数取得
                    var msRtnOverRows = dtApproved.AsEnumerable()
                                         .Where(row => (string)row["STATUS"] == "4").OrderBy(row => row["ID"]);

                    if (msRtnOverRows.Count() > 0)
                    {
                        dtMSRtnOver = msRtnOverRows.CopyToDataTable();
                    }
                }

                lblContractRTNCnt.Text = dtContract.Rows.Count.ToString("#,0");
                lblMSRTNCnt.Text = dtMSRtn.Rows.Count.ToString("#,0");
                lblMSRTNOverCnt.Text = dtMSRtnOver.Rows.Count.ToString("#,0");
                lblNonApprovedCnt.Text = dtNonApproved.Rows.Count.ToString("#,0");

                // 画面上の追跡番号残数セット
                lblTrackingNoRemain.Text = dtTrackingNo.Rows.Count.ToString("#,0");

                // 帳票出力対象の全ての件数が全て0件の場合
                if (dtContract.Rows.Count <= 0 && dtMSRtn.Rows.Count <= 0 && dtMSRtnOver.Rows.Count <= 0 && dtNonApproved.Rows.Count <= 0)                
                {
                    dateShippingDate.Enabled = false;
                    btnSlipPrint.Enabled = false;
                    checkRegistDate.Enabled = false;

                    // アラートフラグがTrueの場合表示
                    if (rtnTrgMessageFlg)
                    {
                        new clsMessageBox().MessageBoxOKOnly("返却対象はありません。", "警告", MessageBoxIcon.Warning);                        
                        return;
                    }
                    
                }
                // 未承認の件数が1件以上の場合
                if (dtNonApproved.Rows.Count > 0)
                {
                    new clsMessageBox().MessageBoxOKOnly("未承認があります、承認処理をしてください。", "警告", MessageBoxIcon.Warning);
                    dateShippingDate.Enabled = false;
                    btnSlipPrint.Enabled = false;
                    checkRegistDate.Enabled = false;
                    return;
                }

            }
            catch (Exception ex)
            {
                _logger.Fatal("テーブルから対象データ取得でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
            finally
            {
                _logger.Info("承認対象件数取得処理：終了");
            }
            
        }
        #endregion

        #region 出荷日指定日付設定（システム日付＋加算日数、土日は除く）
        private void setShiplingDate()
        {
            // 出荷日指定日付設定            
            _logger.Debug("出荷日指定日付設定");
            // 現在日時
            var shukka_Shitei_Date = DateTime.Now;
            for (int weekday_Count = 0; weekday_Count < SHIPPING_DATE_ADD_DAYS;)
            {
                // 日時加算
                shukka_Shitei_Date = shukka_Shitei_Date.AddDays(1);
                // 土日判定
                if (shukka_Shitei_Date.ToString("ddd") != "土" &&
                    shukka_Shitei_Date.ToString("ddd") != "日")
                {
                    // 平日のためカウントアップ
                    weekday_Count++;
                }
            }
            lblHiddenShippingDate.Text = shukka_Shitei_Date.ToString("yyyy/MM/dd");
            dateShippingDate.Value = shukka_Shitei_Date;
        }

        #endregion

        #region MS発送_QMSテーブル登録処理
        private void registMSShippingQMS()
        {            
            if (dtContract.Rows.Count > 0)
            {
                // 契約者返却件数が存在する場合、登録処理を行う
                int processCnt = 0;

                _logger.Info("MS発送_QMSテーブル登録処理：開始");

                try
                {
                    // トランザクション開始
                    //dao.BeginTransaction();

                    foreach (DataRow row in dtContract.Rows)
                    {
                        processCnt++;

                        // 追跡番号取得
                        TrackingNumberEntity contactInfo = dao.Select_Usable_T_MS_YUU_TRACKING_NUMBER();

                        // 発送QMSのMAX ID取得
                        int maxId = dao.Select_MaxID_T_MS_SHIPPING_QMS();

                        _logger.Debug($"T_MS_PB_SHIPPING_QMSのMAX ID：[{maxId}]");


                        _logger.Debug($"発送QMS登録対象データ CONTROL_NO：[{row["CONTROL_NO"].ToString()}]");

                        // 発送QMS登録対象データ設定
                        clsMsShippingQmsData qmsData = new clsMsShippingQmsData
                        {
                            ID = maxId + 1,
                            SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                            CONTACT_NO = contactInfo.TRACKING_NO,
                            CONTROL_NO = row["CONTROL_NO"].ToString(),
                            CONTRACT_NO = row["CONTRACT_NO"].ToString(),
                            REGIST_DATE = now,
                            REGIST_USER_NAME = _userName,
                            PROCESS_NO = processCnt
                        };

                        // 発送QMSテーブルデータ登録
                        dao.Insert_ContractorRtn_T_MS_SHIPPING_QMS(qmsData);

                        // 追跡番号更新
                        dao.Update_T_MS_YUU_TRACKING_NUMBER(contactInfo.TRACKING_NO);
                    }

                    // コミット
                    //dao.Commit();

                    // 処理履歴更新
                    setProcessHistoryTbl("発送QMS作成", null, dtContract.Rows.Count);
                }
                catch (Exception ex)
                {

                    if (ex is InnerException)
                    {
                        throw;
                    }
                    else
                    {
                        // ロールバック
                        //dao.Rollback();
                        _logger.Fatal("MS発送_QMSテーブル登録処理でエラーが発生しました。");
                        _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                        new clsMessageBox().MessageBoxOKOnly("MS発送_QMSテーブル登録処理でエラーが発生しました。" + Environment.NewLine +"開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                        throw;
                    }
                }
                finally
                {
                    _logger.Info("MS発送_QMSテーブル登録処理：終了");
                }

            }
                     
        }
        #endregion

        #region 帳票出力処理
        private void outputShippingSlip()
        {

            _logger.Info("帳票出力処理：開始");

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string msRtnShppingListFile = string.Empty;
                string checkSheetFile = string.Empty;
                string conRtnshppingListFile = string.Empty;
                string yuPackSlipFile = string.Empty;
                
                // 発送QMSデータより契約者返却帳票出力対象データ取得
                var dtQms = dao.Select_ShippingDate_T_MS_SHIPPING_QMS(dateShippingDate.Value.ToString("yyyyMMdd"));

                _logger.Info($"MS返却分の帳票出力対象件数：MS返却件数[{dtMSRtn.Rows.Count}]、MS返却(超過)件数[{dtMSRtnOver.Rows.Count}]");
                _logger.Info($"契約者返却分の帳票出力対象件数：契約者返却件数[{dtQms.Rows.Count}]");


                
                // MS返却発送リストデータ取得
                List<clsMSRtnShippingListRecord> lstMSRtnShippingData = getMSRtnShippincCheckData();

                // MS返却データが存在する場合
                if (lstMSRtnShippingData.Count > 0)
                {
                    // MS返却発送リスト作成
                    msRtnShppingListFile = new clsMSRtnShippingList()
                    {
                        lstShippingListData = lstMSRtnShippingData,
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                        SHIPPING_SLIP_TYPE = ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"]
                    }.CreateCheckSheet();

                    // MS返却分の梱包ラインテーブル登録処理
                    registMSRtnPackingLineTBL(lstMSRtnShippingData.Count);

                    // MS返却分の発送帳票出力済みデータのエスカレテーブル更新処理
                    updateEscalationTBL(dtMSRtn);       // MS返却
                    updateEscalationTBL(dtMSRtnOver);   // MS返却（超過）

                }

                // 伝票チェックシート対象データ取得
                List<clsShippingCheckSheetRecord> lstShippingCheckListData = getShippincCheckListData(dtQms);

                // 契約者返却発送リスト対象データ取得
                List<clsMSRtnShippingListRecord> lstContactorRtnShippingData = getContractorRtnShippingListData(dtQms);

                // MSゆうパック配送伝票データ取得
                List<clsDeliverySlipRecord> lstSlipData = getDeliverySlipData(dtQms);

                if (dtQms.Rows.Count > 0)
                {
                    // 伝票チェックリスト作成
                    checkSheetFile = new clsShippingCheckSheet()
                    {
                        lstChecsheetData = lstShippingCheckListData,
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                        SHIPPING_SLIP_TYPE = ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"]
                    }.CreateShippingCheckSheet();

                    // 契約者返却発送リスト出力
                    conRtnshppingListFile = new clsMSRtnShippingList()
                    {
                        lstShippingListData = lstContactorRtnShippingData,
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                        SHIPPING_SLIP_TYPE = ConfigurationManager.AppSettings["MSPB003_SLIP_CONTRACTOR_RETURN_HEADER"]
                    }.CreateCheckSheet();
                    
                    // MSゆうパック配送伝票作成
                    yuPackSlipFile = new clsDeliverySlip()
                    {
                        lstDeliverySlipData = lstSlipData,
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                        SHIPPING_SLIP_TYPE = ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"]
                    }.CreateDeliverySlip();
                                        
                    // 契約者返却分の梱包ラインテーブル登録処理
                    registContractorRtnPackingLineTBL(dtQms.Rows.Count);

                    // 契約者返却分の発送帳票出力済みデータのエスカレテーブル更新処理
                    updateEscalationTBL(dtContract);       // 契約者返却

                    // 処理履歴更新
                    setProcessHistoryTbl("ゆうパック配送伝票印字", Path.GetFileName(yuPackSlipFile), dtContract.Rows.Count);
                    setProcessHistoryTbl("伝票チェックシート", Path.GetFileName(checkSheetFile), dtContract.Rows.Count);
                    

                }
                
                var msRtnCnt = string.IsNullOrEmpty(msRtnShppingListFile) ? 0 : 1;
                var conRtnCnt = string.IsNullOrEmpty(checkSheetFile) ? 0 : 1;
                var checkListCnt = string.IsNullOrEmpty(conRtnshppingListFile) ? 0 : 1;
                var yuPackCnt = string.IsNullOrEmpty(yuPackSlipFile) ? 0 : 1;

                // 終了メッセージ
                new clsMessageBox().MessageBoxOKOnly("発送帳票出力が完了しました。" + Environment.NewLine +
                                                     $"ＭＳ返却出力対象頁数　： {msRtnCnt}頁" + Environment.NewLine +
                                                     $"契約者返却出力対象頁数： {conRtnCnt + checkListCnt + yuPackCnt}頁", "完了", MessageBoxIcon.Information);

                this.Cursor = Cursors.WaitCursor;
                                
                // 印刷画面を表示する
                if (lstMSRtnShippingData.Count > 0)
                {
                    new comPdfFile().pdfPrintOpen(msRtnShppingListFile);
                }
                if (dtQms.Rows.Count > 0)
                {
                    new comPdfFile().pdfPrintOpen(checkSheetFile);
                    new comPdfFile().pdfPrintOpen(conRtnshppingListFile);
                    new comPdfFile().pdfPrintOpen(yuPackSlipFile);
                }

                rtnTrgMessageFlg = false;

                // 画面再読込
                // 出荷日指定日付設定（システム日付＋1、土日は除く）
                setShiplingDate();
                // 画面上の発送帳票出力対象件数設定
                setSendSlipTargeCntDisplay();
                
            }
            catch (Exception ex)
            {
                if(ex is InnerException)
                {
                    throw;
                }
                else
                {
                    _logger.Fatal("帳票出力処理でエラーが発生しました。");
                    _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                    new clsMessageBox().MessageBoxOKOnly("帳票出力処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                    throw;
                }                
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _logger.Info("帳票出力処理：終了");
            }

        }
        #endregion

        #region MS返却発送リストデータ取得
        /// <summary>
        /// MS返却発送リストデータ取得
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private List<clsMSRtnShippingListRecord> getMSRtnShippincCheckData()
        {
            _logger.Info("MS返却発送リスト対象データ取得");

            // 発送リスト対象データ保持用リスト
            List<clsMSRtnShippingListRecord> lstData = new List<clsMSRtnShippingListRecord>();

            // MS返却データが存在する場合
            if (dtMSRtn.Rows.Count > 0)
            {
                foreach (DataRow row in dtMSRtn.Rows)
                {
                    clsMSRtnShippingListRecord trgData = new clsMSRtnShippingListRecord
                    {
                        ID = (int)row["ID"],
                        ESCALATION_REGIST_DATE = (string)row["REGIST_DATE"],
                        CONTROL_NO = (string)row["CONTROL_NO"],
                        CONTRACT_NO = (string)row["CONTRACT_NO"],
                        OUTPUT_DATE = now.ToString("yyyy年MM月dd日"),
                        RETURN_DEST = ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"],
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyy年MM月dd日")
                    };

                    lstData.Add(trgData);
                }
            }
            // MS返却（超過）データが存在する場合
            if (dtMSRtnOver.Rows.Count > 0)
            {
                foreach (DataRow row in dtMSRtnOver.Rows)
                {
                    clsMSRtnShippingListRecord trgData = new clsMSRtnShippingListRecord
                    {
                        ID = (int)row["ID"],
                        ESCALATION_REGIST_DATE = (string)row["REGIST_DATE"],
                        CONTROL_NO = (string)row["CONTROL_NO"],
                        CONTRACT_NO = (string)row["CONTRACT_NO"],
                        OUTPUT_DATE = now.ToString("yyyy年MM月dd日"),
                        RETURN_DEST = ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"],
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyy年MM月dd日")
                    };

                    lstData.Add(trgData);
                }
            }

            _logger.Info($"MS返却発送リスト対象データ件数：[{lstData.Count}]");

            // NOの昇順でソート
            return lstData.OrderBy(x => x.ID).ToList();

        }
        #endregion

        #region 伝票チェックシート対象データ取得
        /// <summary>
        /// 伝票チェックシート対象データ取得
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private List<clsShippingCheckSheetRecord> getShippincCheckListData(DataTable dt)
        {
            _logger.Debug("伝票チェックシート対象データ取得");

            // 発送リスト対象データ保持用リスト
            List<clsShippingCheckSheetRecord> lstData = new List<clsShippingCheckSheetRecord>();

            // 契約者返却データが存在する場合
            if (dt.Rows.Count > 0)
            {                
                foreach (DataRow row in dt.Rows)
                {
                    
                    clsShippingCheckSheetRecord trgData = new clsShippingCheckSheetRecord
                    {
                        ID = (int)row["ID"],
                        DELIVERY_SLIP_CONTROL_NO = (string)row["DELIVERY_SLIP_CONTROL_NO"],
                        SEND_DEST_POSTAL_CODE = (string)row["SEND_DEST_POSTAL_CODE"],
                        SEND_DEST_ADDRESS = (string)row["SEND_DEST_ADDRESS"],
                        SEND_DEST_NAME = (string)row["SEND_DEST_NAME"],
                        SEND_DEST_TEL_NO = string.IsNullOrEmpty(row["SEND_DEST_TEL_NO"].ToString()) ? "" : (string)row["SEND_DEST_TEL_NO"],
                        SHIPPING_DATE = (string)row["SHIPPING_DATE"]
                    };

                    lstData.Add(trgData);
                }
            }

            _logger.Info($"伝票チェックシート対象データ件数：[{lstData.Count}]");

            // NOの昇順でソート
            return lstData.OrderBy(x => x.ID).ToList();

        }
        #endregion

        #region 契約者返却発送リストデータ取得
        /// <summary>
        /// 契約者返却発送リストデータ取得
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private List<clsMSRtnShippingListRecord> getContractorRtnShippingListData(DataTable dt)
        {
            _logger.Debug("契約者返却発送リスト対象データ取得");

            // 発送リスト対象データ保持用リスト
            List<clsMSRtnShippingListRecord> lstData = new List<clsMSRtnShippingListRecord>();

            // 契約者返却データが存在する場合
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    clsMSRtnShippingListRecord trgData = new clsMSRtnShippingListRecord
                    {
                        ID = (int)row["ID"],
                        ESCALATION_REGIST_DATE = (string)row["REGIST_DATE"],
                        CONTROL_NO = (string)row["CONTROL_NO"],
                        CONTRACT_NO = (string)row["CONTRACT_NO"],
                        OUTPUT_DATE = now.ToString("yyyy年MM月dd日"),
                        RETURN_DEST = ConfigurationManager.AppSettings["MSPB003_SLIP_CONTRACTOR_RETURN_HEADER"],
                        SHIPPING_DATE = dateShippingDate.Value.ToString("yyyy年MM月dd日")
                    };

                    lstData.Add(trgData);
                }
            }

            _logger.Info($"契約者返却発送リスト対象データ件数：[{lstData.Count}]");

            // NOの昇順でソート
            return lstData.OrderBy(x => x.ID).ToList();

        }
        #endregion

        #region MSゆうパック配送伝票データ取得
        /// <summary>
        /// MSゆうパック配送伝票データ取得
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<clsDeliverySlipRecord> getDeliverySlipData(DataTable dt)
        {
            _logger.DebugFormat("MSゆうパック配送伝票データ取得 開始");

            //会社情報取得
            this.CompanyInfo = getCompanyInfo();

            List<clsDeliverySlipRecord> lstData = new List<clsDeliverySlipRecord>();


            // 契約者返却データが存在する場合
            if (dt.Rows.Count > 0)
            {
                string sortingNo = string.Empty;

                foreach (DataRow row in dt.Rows)
                {

                    try
                    {
                        DataTable dtSortingNo = dao.Select_M_SORTING_CODE(row["SEND_DEST_POSTAL_CODE"].ToString());
                        if (dt.Rows.Count <= 0)
                        {
                            sortingNo = "";
                        }
                        else
                        {
                            sortingNo = dtSortingNo.Rows[0]["SORTING_NO"].ToString();
                        }
                    }
                    catch(Exception ex)
                    {
                        _logger.Fatal("仕訳コードマスタから仕分け番号取得jでエラーが発生しました。");
                        _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                        new clsMessageBox().MessageBoxOKOnly("仕訳コードマスタからデータ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                        throw new InnerException();
                    }

                    clsDeliverySlipRecord trgData = new clsDeliverySlipRecord
                    {
                        SEND_DEST_POSTAL_CODE = (string)row["SEND_DEST_POSTAL_CODE"],
                        SEND_DEST_TEL_NO = string.IsNullOrEmpty(row["SEND_DEST_TEL_NO"].ToString()) ? "" : (string)row["SEND_DEST_TEL_NO"],                        
                        SEND_DEST_ADDRESS = (string)row["SEND_DEST_ADDRESS"],
                        SEND_DEST_NAME = (string)row["SEND_DEST_NAME"],
                        CONTRACT_NO = (string)row["CONTRACT_NO"],
                        DELIVERY_SLIP_CONTROL_NO = (string)row["DELIVERY_SLIP_CONTROL_NO"],
                        CONTACT_NO = (string)row["CONTACT_NO"],
                        ITEM_NAME = (string)row["ITEM_NAME"],
                        SHIPPING_DATE = (string)row["SHIPPING_DATE"],
                        YUPACK_CUSTOMER_NO = this.CompanyInfo.YUPACK_CUSTOMER_NO,
                        SORTING_NO = sortingNo
                    };

                    lstData.Add(trgData);
                }
            }

            _logger.Info($"MSゆうパック配送伝票データ件数：[{lstData.Count}]");

            return lstData.OrderBy(x => x.ID).ToList();
        }
        #endregion

        #region 会社情報取得
        /// <summary>
        /// 会社情報取得
        /// </summary>
        /// <returns></returns>
        private clsCompany getCompanyInfo()
        {
            
            clsCompany Company;

            try
            {
                _logger.Debug("会社情報取得 開始");

                Company = dao.Select_M_COMPANY(ConfigurationManager.AppSettings["COMPANY_CODE"]).Select(x => new clsCompany()
                {
                    COMPANY_CODE = x.COMPANY_CODE,
                    COMPANY_RYAKU = x.COMPANY_RYAKU,
                    COMPANY_NAME_RYAKU = x.COMPANY_NAME_RYAKU,
                    FORMAL_NAME = x.FORMAL_NAME,
                    POSTAL_CODE = x.POSTAL_CODE,
                    ADDRESS = x.ADDRESS,
                    YUPACK_CUSTOMER_NO = x.YUPACK_CUSTOMER_NO,
                    RETURNPACK_CUSTOMER_NO = x.RETURNPACK_CUSTOMER_NO,
                    YUPACKET_CUSTOMER_NO = x.YUPACK_CUSTOMER_NO,
                    REGULAR_MAIL_COUSTOMER_NO = x.REGULAR_MAIL_COUSTOMER_NO
                }).FirstOrDefault();

                return Company;

            }
            catch (Exception ex)
            {
                _logger.Fatal("梱包ラインテーブル登録処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブル登録処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw new InnerException();                
            }
            finally
            {
                _logger.Debug("会社情報取得 終了");
            }
        }
        #endregion

        #region 契約者返却の梱包ラインテーブル登録処理
        /// <summary>
        /// 契約者返却の梱包ラインテーブル登録処理
        /// </summary>
        /// <returns></returns>
        private void registContractorRtnPackingLineTBL(int packingCnt)
        {
            _logger.Info("梱包ラインテーブル登録処理：開始");

            try
            {
                // 梱包ラインテーブルよりMAX IDを取得
                int maxId = dao.Select_MaxID_T_MS_PACKING_LINE();

                _logger.Debug($"T_MS_PB_PACKING_LINEのMAX ID：[{maxId}]");

                PackingLineEntity plEntity = new PackingLineEntity
                {
                    ID = maxId + 1,
                    SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                    INSURANCE_CODE = "1",   // 1：MS　2：AD
                    RETURN_PLACE = "1",     // 1：契約者返却　2：MS返却
                    PACKING_COUNT = packingCnt,
                    REGIST_DATE = now.ToString("yyyyMMdd"),
                    REGIST_USER_NAME = _userName

                };
                
                // 梱包ラインテーブルに契約者返却データ登録処理
                dao.Insert_ContractorRtn_T_MS_PACKING_LINE(plEntity);
            }
            catch (Exception ex)
            {
                _logger.Fatal("梱包ラインテーブル登録処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブル登録処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                _logger.Info("梱包ラインテーブル登録処理：終了");
            }            
        }
        #endregion

        #region MS返却の梱包ラインテーブル登録処理
        /// <summary>
        /// MS返却の梱包ラインテーブル登録処理
        /// </summary>
        /// <returns></returns>
        private void registMSRtnPackingLineTBL(int packingCnt)
        {
            _logger.Info("梱包ラインテーブル登録処理：開始");

            try
            {
                // 梱包ラインテーブルよりMAX IDを取得
                int maxId = dao.Select_MaxID_T_MS_PACKING_LINE();

                _logger.Debug($"T_MS_PB_PACKING_LINEのMAX ID：[{maxId}]");

                PackingLineEntity plEntity = new PackingLineEntity
                {
                    ID = maxId + 1,
                    SHIPPING_DATE = dateShippingDate.Value.ToString("yyyyMMdd"),
                    INSURANCE_CODE = "1",   // 1：MS　2：AD
                    RETURN_PLACE = "2",     // 1：契約者返却　2：MS返却
                    PACKING_COUNT = packingCnt,
                    REGIST_DATE = now.ToString("yyyyMMdd"),
                    REGIST_USER_NAME = _userName
                };

                // 梱包ラインテーブルに契約者返却データ登録処理
                dao.Insert_ContractorRtn_T_MS_PACKING_LINE(plEntity);
            }
            catch (Exception ex)
            {
                _logger.Fatal("梱包ラインテーブル登録処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブル登録処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                _logger.Info("梱包ラインテーブル登録処理：終了");
            }
        }
        #endregion

        #region エスカレテーブル更新処理
        /// <summary>
        /// エスカレテーブル更新処理
        /// </summary>
        /// <returns></returns>
        private void updateEscalationTBL(DataTable dt)
        {
            _logger.Info("エスカレテーブル更新処理：開始");

            try
            {
                var shippingDate = dateShippingDate.Value.ToString("yyyyMMdd");

                foreach (DataRow row in dt.Rows)
                {
                    dao.Update_ShippingSlip_T_ESCALATION(shippingDate, "5", (string)row["CONTROL_NO"]);
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal("エスカレテーブル更新処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("エスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                _logger.Info("エスカレテーブル更新処理：終了");
            }
        }
        #endregion

        #region 処理履歴登録
        /// <summary>
        /// 処理履歴登録
        /// </summary>
        /// <param name="processText"></param>
        /// <param name="outFileName"></param>
        /// <param name="outCount"></param>
        private void setProcessHistoryTbl(string processText, string outFileName, int outCount)
        {
            _logger.Debug("処理履歴登録");

            try
            {
                int maxSeqNo = dao.Select_MaxSeqNo_T_PROCESS_HISTORY();

                _logger.Debug($"T_PROCESS_HISTORYのMAX SEQ_NO：[{maxSeqNo}]");

                ProcessHistoryEnity entity = new ProcessHistoryEnity()
                {
                    SEQ_NO = maxSeqNo + 1,
                    PROCESS_TEXT = processText,
                    OUTPUT_FILE_NAME = outFileName,
                    OUTPUT_COUNT = outCount,
                    UPDATE_USER = _userName
                };

                dao.Insert_T_PROCESS_HISTORY(entity);
            }
            catch (Exception ex)
            {
                _logger.Fatal("処理履歴登録処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("処理履歴登録でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw new InnerException();
            }
        }
        #endregion

        #endregion


    }
}