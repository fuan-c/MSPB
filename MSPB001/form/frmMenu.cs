﻿using System;
using System.Windows.Forms;
using MSPB.Common;
using MSPB.MSPB002;
using MSPB.MSPB003;
using MSPB.MSPB004;
using MSPB.MSPB005;
using MSPB.MSPB006;
using MSPB.MSPB007;
using MSPB.MSPB008;
using MSPB.MSPB009;
using MSPB.MSPB010;
using MSPB.MSPB012;
using log4net;

namespace MSPB.MSPB001.form
{
    /// <summary>
    /// メインメニュー画面
    /// </summary>
    class frmMenu:Form
    {
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private static string _userName;
        
        #region デザイン
        private Panel panelTitle;
        private Panel panelSelect;
        private Button btnClose;
        private Button btnUpdateSortingCode;
        private Button btnTrackingNo;
        private Button btnSheetPrint;
        private Button btnShipment;
        private Button btnSendFormPrint;
        private Button btnResponseRegist;
        private Label Header2;
        private Label Header3;
        private Button btnTotalization;
        private Button btnApproval;
        private Button btnSearch;
        private Button btnUserMng;
        private Label Header0;

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.Header2 = new System.Windows.Forms.Label();
            this.Header3 = new System.Windows.Forms.Label();
            this.Header0 = new System.Windows.Forms.Label();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.btnApproval = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUserMng = new System.Windows.Forms.Button();
            this.btnTotalization = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateSortingCode = new System.Windows.Forms.Button();
            this.btnTrackingNo = new System.Windows.Forms.Button();
            this.btnSheetPrint = new System.Windows.Forms.Button();
            this.btnShipment = new System.Windows.Forms.Button();
            this.btnSendFormPrint = new System.Windows.Forms.Button();
            this.btnResponseRegist = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.Header2);
            this.panelTitle.Controls.Add(this.Header3);
            this.panelTitle.Controls.Add(this.Header0);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(600, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // Header2
            // 
            this.Header2.AutoSize = true;
            this.Header2.BackColor = System.Drawing.Color.Transparent;
            this.Header2.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Header2.ForeColor = System.Drawing.Color.Black;
            this.Header2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Header2.Location = new System.Drawing.Point(169, 55);
            this.Header2.Name = "Header2";
            this.Header2.Size = new System.Drawing.Size(183, 36);
            this.Header2.TabIndex = 0;
            this.Header2.Text = "メインメニュー";
            this.Header2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Header3
            // 
            this.Header3.AutoSize = true;
            this.Header3.BackColor = System.Drawing.Color.Transparent;
            this.Header3.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Header3.ForeColor = System.Drawing.Color.Black;
            this.Header3.Location = new System.Drawing.Point(334, 55);
            this.Header3.Name = "Header3";
            this.Header3.Size = new System.Drawing.Size(111, 36);
            this.Header3.TabIndex = 0;
            this.Header3.Text = "（ＯＰ）";
            this.Header3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Header0
            // 
            this.Header0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Header0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Header0.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Header0.Location = new System.Drawing.Point(12, 9);
            this.Header0.Name = "Header0";
            this.Header0.Size = new System.Drawing.Size(576, 91);
            this.Header0.TabIndex = 0;
            this.Header0.Text = "MS　私物返却管理DB";
            this.Header0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnApproval);
            this.panelSelect.Controls.Add(this.btnSearch);
            this.panelSelect.Controls.Add(this.btnUserMng);
            this.panelSelect.Controls.Add(this.btnTotalization);
            this.panelSelect.Controls.Add(this.btnClose);
            this.panelSelect.Controls.Add(this.btnUpdateSortingCode);
            this.panelSelect.Controls.Add(this.btnTrackingNo);
            this.panelSelect.Controls.Add(this.btnSheetPrint);
            this.panelSelect.Controls.Add(this.btnShipment);
            this.panelSelect.Controls.Add(this.btnSendFormPrint);
            this.panelSelect.Controls.Add(this.btnResponseRegist);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelect.Location = new System.Drawing.Point(0, 100);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(600, 549);
            this.panelSelect.TabIndex = 0;
            // 
            // btnApproval
            // 
            this.btnApproval.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnApproval.Location = new System.Drawing.Point(188, 278);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(225, 40);
            this.btnApproval.TabIndex = 8;
            this.btnApproval.Text = "エスカレ回答承認";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Visible = false;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Location = new System.Drawing.Point(188, 340);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(225, 40);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUserMng
            // 
            this.btnUserMng.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUserMng.Location = new System.Drawing.Point(188, 400);
            this.btnUserMng.Name = "btnUserMng";
            this.btnUserMng.Size = new System.Drawing.Size(225, 40);
            this.btnUserMng.TabIndex = 10;
            this.btnUserMng.Text = "ユーザ管理";
            this.btnUserMng.UseVisualStyleBackColor = true;
            this.btnUserMng.Visible = false;
            this.btnUserMng.Click += new System.EventHandler(this.btnUserMng_Click);
            // 
            // btnTotalization
            // 
            this.btnTotalization.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTotalization.Location = new System.Drawing.Point(328, 32);
            this.btnTotalization.Name = "btnTotalization";
            this.btnTotalization.Size = new System.Drawing.Size(225, 40);
            this.btnTotalization.TabIndex = 2;
            this.btnTotalization.Text = "集計";
            this.btnTotalization.UseVisualStyleBackColor = true;
            this.btnTotalization.Click += new System.EventHandler(this.btnTotalization_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(188, 481);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(225, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateSortingCode
            // 
            this.btnUpdateSortingCode.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdateSortingCode.Location = new System.Drawing.Point(328, 154);
            this.btnUpdateSortingCode.Name = "btnUpdateSortingCode";
            this.btnUpdateSortingCode.Size = new System.Drawing.Size(225, 40);
            this.btnUpdateSortingCode.TabIndex = 6;
            this.btnUpdateSortingCode.Text = "仕分けコード更新";
            this.btnUpdateSortingCode.UseVisualStyleBackColor = true;
            this.btnUpdateSortingCode.Click += new System.EventHandler(this.btnUpdateSortingCode_Click);
            // 
            // btnTrackingNo
            // 
            this.btnTrackingNo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTrackingNo.Location = new System.Drawing.Point(328, 93);
            this.btnTrackingNo.Name = "btnTrackingNo";
            this.btnTrackingNo.Size = new System.Drawing.Size(225, 40);
            this.btnTrackingNo.TabIndex = 4;
            this.btnTrackingNo.Text = "追跡番号生成";
            this.btnTrackingNo.UseVisualStyleBackColor = true;
            this.btnTrackingNo.Click += new System.EventHandler(this.btnTrackingNo_Click);
            // 
            // btnSheetPrint
            // 
            this.btnSheetPrint.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSheetPrint.Location = new System.Drawing.Point(42, 215);
            this.btnSheetPrint.Name = "btnSheetPrint";
            this.btnSheetPrint.Size = new System.Drawing.Size(225, 40);
            this.btnSheetPrint.TabIndex = 7;
            this.btnSheetPrint.Text = "エスカレシート出力";
            this.btnSheetPrint.UseVisualStyleBackColor = true;
            this.btnSheetPrint.Click += new System.EventHandler(this.btnSheetPrint_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShipment.Location = new System.Drawing.Point(42, 154);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(225, 40);
            this.btnShipment.TabIndex = 5;
            this.btnShipment.Text = "出荷処理";
            this.btnShipment.UseVisualStyleBackColor = true;
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnSendFormPrint
            // 
            this.btnSendFormPrint.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSendFormPrint.Location = new System.Drawing.Point(42, 93);
            this.btnSendFormPrint.Name = "btnSendFormPrint";
            this.btnSendFormPrint.Size = new System.Drawing.Size(225, 40);
            this.btnSendFormPrint.TabIndex = 3;
            this.btnSendFormPrint.Text = "発送帳票出力";
            this.btnSendFormPrint.UseVisualStyleBackColor = true;
            this.btnSendFormPrint.Click += new System.EventHandler(this.btnSendFormPrint_Click);
            // 
            // btnResponseRegist
            // 
            this.btnResponseRegist.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnResponseRegist.Location = new System.Drawing.Point(42, 32);
            this.btnResponseRegist.Name = "btnResponseRegist";
            this.btnResponseRegist.Size = new System.Drawing.Size(225, 40);
            this.btnResponseRegist.TabIndex = 1;
            this.btnResponseRegist.Text = "エスカレ回答登録";
            this.btnResponseRegist.UseVisualStyleBackColor = true;
            this.btnResponseRegist.Click += new System.EventHandler(this.btnResponseRegist_Click);
            // 
            // frmMenu
            // 
            this.ClientSize = new System.Drawing.Size(600, 649);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS 私物返却管理DB メインメニュー";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMenu(string authority, string userName)
        {
            _logger.Info("私物返却管理DB：メインメニュー 開始");
            _userName = userName;
            InitializeComponent();

            // ユーザ権限が管理者の場合ヘッダー名と管理者用ボタン活性化
            if (authority == "1")
            {                
                this.Header3.Text = "（ＳＶ）";
                this.btnApproval.Visible = true;                
                this.btnSearch.Visible = true;
                this.btnUserMng.Visible = true;
            }
            
            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

        }
        #endregion

        #region イベント

        #region エスカレ回答登録ボタン押下
        /// <summary>
        /// エスカレ回答登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResponseRegist_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：エスカレ回答登録ボタン押下");
            this.Hide();
            clsMSPB002 p = new clsMSPB002();
            p.procStart(_userName);
            this.Show();
        }
        #endregion

        #region 発送帳票出力ボタン押下
        /// <summary>
        /// 発送帳票出力ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFormPrint_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：発送帳票出荷ボタン押下");
            this.Hide();
            clsMSPB003 p = new clsMSPB003();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region 出荷処理ボタン押下
        /// <summary>
        /// 出荷処理ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipment_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：出荷処理ボタン押下");
            this.Hide();
            clsMSPB004 p = new clsMSPB004();
            p.procStart(_userName);
            this.Show();
        }
        #endregion

        #region エスカレシート出力ボタン押下
        /// <summary>
        /// エスカレシート出力ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSheetPrint_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：エスカレシートボタン押下");            
            this.Hide();
            clsMSPB005 p = new clsMSPB005();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region 集計ボタン押下
        /// <summary>
        /// 集計ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTotalization_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：集計ボタン押下");
            this.Hide();
            clsMSPB006 p = new clsMSPB006();
            p.procStart();
            this.Show();
        }
        #endregion
        
        #region 追跡番号生成ボタン押下
        /// <summary>
        /// 追跡番号生成ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrackingNo_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：追跡番号生成ボタン押下");
            this.Hide();
            clsMSPB007 p = new clsMSPB007();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region 仕分コード更新ボタン押下
        /// <summary>
        /// 仕分コード更新ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateSortingCode_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：仕分コード更新ボタン押下");
            this.Hide();
            clsMSPB008 p = new clsMSPB008();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region エスカレ承認ボタン押下
        /// <summary>
        /// エスカレ承認ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApproval_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：エスカレ承認ボタン押下");
            this.Hide();
            clsMSPB009 p = new clsMSPB009();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region 検索ボタン押下
        /// <summary>
        /// 検索ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：検索ボタン押下");
            this.Hide();
            clsMSPB010 p = new clsMSPB010();
            p.procStart(_userName);
            this.Show();
        }
        #endregion
        
        #region ユーザ管理ボタン押下
        /// <summary>
        /// ユーザ管理ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserMng_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：ユーザ管理ボタン押下");
            this.Hide();
            clsMSPB012 p = new clsMSPB012();
            p.procStart();
            this.Show();
        }
        #endregion
        
        #region 終了ボタン押下
        /// <summary>
        /// 終了ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            _logger.Debug("メインメニュー：終了ボタン押下");
            _logger.Info("私物返却管理DB：メインメニュー 終了");
            this.Close();            
        }
        #endregion

        #endregion
    }
}
