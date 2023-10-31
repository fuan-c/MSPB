﻿using System;
using System.Windows.Forms;
using MSPB.Common;
using MSPB.MSPB.dao;
using MSPB.MSPB001;
using System.Data;
using log4net;

namespace MSPB.MSPB.form
{
    /// <summary>
    /// ログイン画面
    /// </summary>
    class frmLogin:Form
    {
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region デザイン
        private Panel panelSelect;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtLoginId;
        private Label label1;
        private Label Header0;
        private Panel panelTitle;
        private Panel panel1;
        private Label Header1;
        private Button btnClose;

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSelect = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Header1 = new System.Windows.Forms.Label();
            this.Header0 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelSelect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnClose);
            this.panelSelect.Controls.Add(this.panel1);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelect.Location = new System.Drawing.Point(0, 100);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(525, 425);
            this.panelSelect.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(386, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtLoginId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Location = new System.Drawing.Point(43, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 275);
            this.panel1.TabIndex = 0;
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLoginId.Location = new System.Drawing.Point(177, 48);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(180, 31);
            this.txtLoginId.TabIndex = 1;
            this.txtLoginId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(60, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ログインＩＤ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLogin.Location = new System.Drawing.Point(174, 181);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(159, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "ログイン";
            this.btnLogin.UseVisualStyleBackColor = true;            
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(60, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "パスワード";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPassword.Location = new System.Drawing.Point(177, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 31);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Header1
            // 
            this.Header1.AutoSize = true;
            this.Header1.BackColor = System.Drawing.Color.Transparent;
            this.Header1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Header1.ForeColor = System.Drawing.Color.Black;
            this.Header1.Location = new System.Drawing.Point(212, 50);
            this.Header1.Name = "Header1";
            this.Header1.Size = new System.Drawing.Size(111, 36);
            this.Header1.TabIndex = 0;
            this.Header1.Text = "ログイン";
            this.Header1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Header0
            // 
            this.Header0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Header0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Header0.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Header0.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Header0.Location = new System.Drawing.Point(9, 8);
            this.Header0.Name = "Header0";
            this.Header0.Size = new System.Drawing.Size(506, 89);
            this.Header0.TabIndex = 0;
            this.Header0.Text = "MS　私物返却管理DB\r\n";
            this.Header0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.Header1);
            this.panelTitle.Controls.Add(this.Header0);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(525, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(525, 525);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS 私物返却管理DB ログイン";
            this.panelSelect.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmLogin()
        {
            _logger.Info("私物返却管理DB：ログイン 開始");
            InitializeComponent();

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion
        #region イベント
        #region ログインボタン押下
        /// <summary>
        /// ログインボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userAuthority = string.Empty;
            string userName = string.Empty;

            //_logger.Info("ログイン処理開始");
            if (this.txtLoginId.Text.Length <= 0)
            {                          
                new clsMessageBox().MessageBoxOKOnly("ログインIDを入力してください。", "警告", MessageBoxIcon.Warning);
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtPassword.Text.Length <= 0)
            {                
                new clsMessageBox().MessageBoxOKOnly("パスワードを入力してください。", "警告", MessageBoxIcon.Warning);
                this.txtPassword.Focus();
                return;
            }

            using (daoMSPB dao = new daoMSPB(this.txtLoginId.Text, "DBConnection"))
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    DataTable dt = dao.SelectEMPLOYEE(this.txtLoginId.Text);

                    this.Cursor = Cursors.Default;

                    // ログインID存在チェック
                    if (dt.Rows.Count <= 0)
                    {
                        _logger.Debug($"ログインID[{this.txtLoginId.Text}]が間違っています。");                        
                        new clsMessageBox().MessageBoxOKOnly("ログインIDが間違っています。", "警告", MessageBoxIcon.Warning);
                        this.txtLoginId.Text = "";
                        this.txtPassword.Text = "";
                        this.txtLoginId.Focus();
                        return;
                    }

                    // 入力されたパスワードと一致可否チェック
                    if (this.txtPassword.Text != dt.Rows[0]["USER_PASSWORD"].ToString())
                    {
                        _logger.Debug($"パスワードが間違っています。");                        
                        new clsMessageBox().MessageBoxOKOnly("パスワードが間違っています。", "警告", MessageBoxIcon.Warning);
                        this.txtPassword.Text = "";
                        this.txtPassword.Focus();
                        return;
                    }

                    // 担当者の情報保持
                    userAuthority = dt.Rows[0]["USER_AUTHORITY"].ToString();
                    userName = dt.Rows[0]["USER_NAME"].ToString();

                    _logger.Info($"ログインユーザＩＤ：[{this.txtLoginId.Text}]、ユーザ名：[{userName}]、権限：[{userAuthority}]");

                } catch (Exception ex)
                {
                    _logger.Fatal("管理者テーブルから対象データ取得でエラーが発生しました。");
                    _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                    new clsMessageBox().MessageBoxOKOnly("管理者テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    //_logger.Info("ログイン処理終了");
                    _logger.Info("私物返却管理DB：ログイン 終了");
                }
            }
            this.Hide();            
            clsMSPB001 p = new clsMSPB001();
            p.procStart(userAuthority, userName);
            this.Close();
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
            _logger.Debug("ログイン処理終了:終了ボタン押下");
            _logger.Info("私物返却管理DB：ログイン 終了");
            this.Close();
        }
        #endregion

        private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }

        #endregion

    }
}
