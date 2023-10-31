using dnp.nulcommon.util;
using log4net;
using MSPB.Common;
using MSPB.MSPB007.dao;
using MSPB.MSPB007.logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace MSPB.MSPB007.form
{

    /// <summary>
    /// 追跡番号生成画面
    /// </summary>
    class frmMSPB007 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFinalTrackingNo;
        private System.Windows.Forms.Label lblBeginTrackingNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTrackingNoFinal;
        private System.Windows.Forms.Label lblRemainingCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIssueCount;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.Label header0;


        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIssueCount = new System.Windows.Forms.TextBox();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFinalTrackingNo = new System.Windows.Forms.Label();
            this.lblBeginTrackingNo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTrackingNoFinal = new System.Windows.Forms.Label();
            this.lblRemainingCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(652, 100);
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
            this.header0.Location = new System.Drawing.Point(200, 14);
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
            this.header1.Location = new System.Drawing.Point(246, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(159, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "追跡番号生成";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtIssueCount);
            this.panel2.Controls.Add(this.txtTrackingNo);
            this.panel2.Controls.Add(this.btnIssue);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblFinalTrackingNo);
            this.panel2.Controls.Add(this.lblBeginTrackingNo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblTrackingNoFinal);
            this.panel2.Controls.Add(this.lblRemainingCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 327);
            this.panel2.TabIndex = 2;
            // 
            // txtIssueCount
            // 
            this.txtIssueCount.BackColor = System.Drawing.Color.White;
            this.txtIssueCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIssueCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtIssueCount.Location = new System.Drawing.Point(338, 178);
            this.txtIssueCount.Name = "txtIssueCount";
            this.txtIssueCount.Size = new System.Drawing.Size(153, 36);
            this.txtIssueCount.TabIndex = 2;
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.BackColor = System.Drawing.Color.White;
            this.txtTrackingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrackingNo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTrackingNo.Location = new System.Drawing.Point(67, 177);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(200, 36);
            this.txtTrackingNo.TabIndex = 1;
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnIssue.Location = new System.Drawing.Point(417, 11);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(208, 35);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "ゆうパック追跡番号発行";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Sienna;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "ゆうバック追跡番号生成";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(280, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 26);
            this.label10.TabIndex = 12;
            this.label10.Text = "―";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinalTrackingNo
            // 
            this.lblFinalTrackingNo.BackColor = System.Drawing.Color.White;
            this.lblFinalTrackingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFinalTrackingNo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFinalTrackingNo.Location = new System.Drawing.Point(338, 257);
            this.lblFinalTrackingNo.Name = "lblFinalTrackingNo";
            this.lblFinalTrackingNo.Size = new System.Drawing.Size(200, 30);
            this.lblFinalTrackingNo.TabIndex = 11;
            this.lblFinalTrackingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeginTrackingNo
            // 
            this.lblBeginTrackingNo.BackColor = System.Drawing.Color.White;
            this.lblBeginTrackingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeginTrackingNo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBeginTrackingNo.Location = new System.Drawing.Point(67, 259);
            this.lblBeginTrackingNo.Name = "lblBeginTrackingNo";
            this.lblBeginTrackingNo.Size = new System.Drawing.Size(200, 30);
            this.lblBeginTrackingNo.TabIndex = 10;
            this.lblBeginTrackingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(329, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 30);
            this.label7.TabIndex = 9;
            this.label7.Text = "終了　追跡番号";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(62, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 30);
            this.label6.TabIndex = 8;
            this.label6.Text = "開始　追跡番号";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(333, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "発行数　指定";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(62, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "開始追跡番号　指定（11桁）";
            // 
            // lblTrackingNoFinal
            // 
            this.lblTrackingNoFinal.BackColor = System.Drawing.Color.White;
            this.lblTrackingNoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrackingNoFinal.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTrackingNoFinal.Location = new System.Drawing.Point(241, 104);
            this.lblTrackingNoFinal.Name = "lblTrackingNoFinal";
            this.lblTrackingNoFinal.Size = new System.Drawing.Size(200, 30);
            this.lblTrackingNoFinal.TabIndex = 3;
            this.lblTrackingNoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrackingNoFinal.Click += new System.EventHandler(this.lblTrackingNoFinal_Click);
            // 
            // lblRemainingCount
            // 
            this.lblRemainingCount.BackColor = System.Drawing.Color.White;
            this.lblRemainingCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemainingCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRemainingCount.Location = new System.Drawing.Point(241, 67);
            this.lblRemainingCount.Name = "lblRemainingCount";
            this.lblRemainingCount.Size = new System.Drawing.Size(128, 30);
            this.lblRemainingCount.TabIndex = 2;
            this.lblRemainingCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(62, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "追跡番号　最終";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(62, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "追跡番号　残数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Location = new System.Drawing.Point(11, 445);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 101);
            this.panel3.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(520, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // frmMSPB007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(670, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB007";
            this.Text = "MS 私物返却管理DB 追跡番号生成";
            this.Load += new System.EventHandler(this.frmMSPB007_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        public frmMSPB007(string userName)
        {
            this.UserName = userName;
            InitializeComponent();


            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion

        #region イベント
        #region フォームロード
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMSPB007_Load(object sender, EventArgs e)
        {
            logger.Info("追跡番号生成フォームロード");

            try
            {
                using (daoMSPB007 dao = new daoMSPB007(this.UserName, "DBConnection"))
                {
                    List<clsTrackingNumber> lstTrackingNumber = dao.SelectT_TRACKING_NUMBER().Select(x => new clsTrackingNumber()
                    {
                        ID = x.ID,
                        TRACKING_NO = x.TRACKING_NO,
                        USE_DATE = x.USE_DATE
                    }).ToList();

                    this.lblRemainingCount.Text = lstTrackingNumber.Count().ToString();
                    if (lstTrackingNumber.Count() > 0)
                    {
                        this.lblTrackingNoFinal.Text = lstTrackingNumber.FirstOrDefault().TRACKING_NO11;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("異常終了しました。", ex);
                MessageBox.Show(this, "異常終了しました。\r\n" + ex.Message + "\r\n" + ex.StackTrace, "異常終了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("追跡番号生成：戻るボタン押下");
            this.Close();
        }
        #endregion
        #endregion
        #endregion

        #region 変数
        /// <summary>
        /// ユーザ名
        /// </summary>
        private string UserName;

        /// <summary>
        /// ログ
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 経過日数
        /// </summary>
        private int ELAPSED_DATE = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MSPRM260_ELAPSED_DATE"]) ?
                                        int.Parse(ConfigurationManager.AppSettings["MSPRM260_ELAPSED_DATE"]) : 100;
        #endregion

        #region 追跡番号発行ボタン押下
        /// <summary>
        /// 追跡番号発行ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIssue_Click(object sender, EventArgs e)
        {
            logger.Info("追跡番号発行ボタン押下");
            try
            {
                //入力チェック
                if (this.txtTrackingNo.Text == string.Empty)
                {
                    logger.DebugFormat("開始追跡番号未入力エラー");
                    MessageBox.Show(this, "開始追跡番号が入力されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.txtIssueCount.Text == string.Empty)
                {
                    logger.DebugFormat("発行数未入力エラー");
                    MessageBox.Show(this, "発行数が入力されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //桁数チェック
                if (this.txtTrackingNo.Text.Length != 11)
                {
                    logger.DebugFormat("開始追跡番号桁数チェックエラー[{0}]", this.txtTrackingNo.Text);
                    MessageBox.Show(this, "開始追跡番号は数字１１桁で指定してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //数字チェック
                if (!CharCheckUtil.IsHalfWidthNumericString(this.txtTrackingNo.Text))
                {
                    logger.DebugFormat("開始追跡番号数字チェックエラー[{0}]", this.txtTrackingNo.Text);
                    MessageBox.Show(this, "開始追跡番号は数字１１桁で指定してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //桁数チェック
                if (this.txtIssueCount.Text.Length > 7)
                {
                    logger.DebugFormat("発行数桁数チェックエラー[{0}]", this.txtIssueCount.Text);
                    MessageBox.Show(this, "発行数は数字７桁以下で指定してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //数字チェック
                if (!CharCheckUtil.IsHalfWidthNumericString(this.txtIssueCount.Text))
                {
                    logger.DebugFormat("発行数数字チェックエラー[{0}]", this.txtIssueCount.Text);
                    MessageBox.Show(this, "発行数は数字７桁以下で指定してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long count = long.Parse(this.txtIssueCount.Text);
                long startNo = long.Parse(this.txtTrackingNo.Text);
                long finalNo = startNo + (count - 1);

                using (daoMSPB007 dao = new daoMSPB007(this.UserName, "DBConnection"))
                {
                    try
                    {
                        dao.BeginTransaction();
                        List<TrackingNumberEnity> lstSaveTrackingNumber = dao.SelectT_TRACKING_NUMBER(startNo.ToString("00000000000"), finalNo.ToString("00000000000")).ToList();

                        if (lstSaveTrackingNumber.Count > 0)
                        {
                            logger.Debug("追跡番号は発行済みです");
                            MessageBox.Show(this, "追跡番号は発行済みです\r\n" + "発行済追跡番号：" + lstSaveTrackingNumber.OrderBy(x => x.TRACKING_NO).FirstOrDefault().TRACKING_NO.Trim('a').Substring(0, 11),
                                "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string msg = string.Format("開始：{0} 終了：{1}\r\n追跡番号を発行します。よろしいですか？", startNo.ToString("00000000000"), finalNo.ToString("00000000000"));
                        logger.Debug(msg.Replace("\r\n", "  "));
                        if (MessageBox.Show(this, msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }

                        //不要データ削除
                        dao.DeleteT_TRACKING_NUMBER(DateTime.Now.AddDays(this.ELAPSED_DATE * -1).ToString("yyyyMMdd"));
                        this.lblBeginTrackingNo.Text = startNo.ToString("00000000000");
                        this.lblFinalTrackingNo.Text = finalNo.ToString("00000000000");

                        int id = dao.getTrackingNumberMaxID();

                        for (long no = 0; no < count; no++)
                        {
                            id += 1;

                            long trakNo = startNo + no;

                            string trackingNo = getTrackingNo(trakNo);

                            new T_TRACKING_NUMBERentity()
                            {
                                ID = id,
                                TRACKING_NO = trackingNo
                            }.InsertEntity(dao.Connection);

                        }

                        //処理履歴
                        setProcessHistoryTbl(dao, "追跡番号生成", (int)count);
                        dao.Commit();

                    }
                    catch
                    {
                        dao.RollBack();
                        throw;
                    }
                    //完了メッセージ
                    logger.DebugFormat("{0}件発行しました", count);
                    MessageBox.Show(this, string.Format("{0}件発行しました", count), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<clsTrackingNumber> lstTrackingNumber = dao.SelectT_TRACKING_NUMBER().Select(x => new clsTrackingNumber()
                    {
                        ID = x.ID,
                        TRACKING_NO = x.TRACKING_NO,
                        USE_DATE = x.USE_DATE
                    }).ToList();

                    this.lblRemainingCount.Text = lstTrackingNumber.Count().ToString();
                    if (lstTrackingNumber.Count() > 0)
                    {
                        this.lblTrackingNoFinal.Text = lstTrackingNumber.FirstOrDefault().TRACKING_NO11;
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Fatal("異常終了しました。", ex);
                MessageBox.Show(this, "異常終了しました。\r\n" + ex.Message + "\r\n" + ex.StackTrace, "異常終了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region 追跡番号取得
        /// <summary>
        /// 追跡番号取得
        /// </summary>
        /// <param name="trackingNo"></param>
        /// <returns></returns>
        private string getTrackingNo(long trackingNo)
        {
            string cd = (trackingNo % 7).ToString();
            return string.Format("a{0}{1}a", trackingNo.ToString("00000000000"), cd);
        }
        #endregion

        #region 処理履歴登録
        /// <summary>
        /// 処理履歴登録
        /// </summary>
        /// <param name="dao"></param>
        /// <param name="outCount"></param>
        private void setProcessHistoryTbl(daoMSPB007 dao, string processText, int outCount)
        {
            logger.Debug("処理履歴登録");

            int seqNo = dao.getProcessHistoryMaxSeqNo();

            seqNo += 1;
            new T_PROCESS_HISTORYentity()
            {
                SEQ_NO = seqNo,
                PROCESS_TEXT = processText,
                OUTPUT_COUNT = outCount,
                UPDATE_DATE = DateTime.Now,
                UPDATE_USER = this.UserName
            }.InsertEntity(dao.Connection);

        }
        #endregion

        private void lblTrackingNoFinal_Click(object sender, EventArgs e)
        {
            string Final_No = lblTrackingNoFinal.Text;
            if (!string.IsNullOrEmpty(lblTrackingNoFinal.Text))
            {
                //クリップボードに文字列をコピーする
                Clipboard.SetText(Final_No);
            }
        }
    }
}