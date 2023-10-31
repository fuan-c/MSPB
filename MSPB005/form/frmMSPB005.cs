using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using MSPB.Common;
using MSPB.MSPB005.dao;
using MSPB.MSPB005.pdf;
using MSPB.MSPB005.common;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace MSPB.MSPB005.form
{
    /// <summary>
    /// エスカレシート出力画面
    /// </summary>
    class frmMSPB005 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_Escalation_List;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTotalOutputCnt;
        private System.Windows.Forms.Button btnEscSheetOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtEscCount;
        private System.Windows.Forms.Label label3;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalOutputCnt = new System.Windows.Forms.Label();
            this.btnEscSheetOutput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEscCount = new System.Windows.Forms.Label();
            this.dataGridView_Escalation_List = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Escalation_List)).BeginInit();
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
            this.header1.Location = new System.Drawing.Point(251, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(231, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "エスカレシート出力";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(592, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalOutputCnt);
            this.panel1.Controls.Add(this.btnEscSheetOutput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEscCount);
            this.panel1.Location = new System.Drawing.Point(8, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 135);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(46, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "総出力件数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalOutputCnt
            // 
            this.txtTotalOutputCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalOutputCnt.BackColor = System.Drawing.Color.White;
            this.txtTotalOutputCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalOutputCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTotalOutputCnt.Location = new System.Drawing.Point(167, 72);
            this.txtTotalOutputCnt.Name = "txtTotalOutputCnt";
            this.txtTotalOutputCnt.Size = new System.Drawing.Size(125, 29);
            this.txtTotalOutputCnt.TabIndex = 0;
            this.txtTotalOutputCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEscSheetOutput
            // 
            this.btnEscSheetOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEscSheetOutput.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEscSheetOutput.Location = new System.Drawing.Point(495, 86);
            this.btnEscSheetOutput.Name = "btnEscSheetOutput";
            this.btnEscSheetOutput.Size = new System.Drawing.Size(194, 35);
            this.btnEscSheetOutput.TabIndex = 3;
            this.btnEscSheetOutput.TabStop = false;
            this.btnEscSheetOutput.Text = "エスカレシート出力";
            this.btnEscSheetOutput.UseVisualStyleBackColor = true;
            this.btnEscSheetOutput.Click += new System.EventHandler(this.btnEscSheetOutput_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "エスカレ件数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEscCount
            // 
            this.txtEscCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEscCount.BackColor = System.Drawing.Color.White;
            this.txtEscCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEscCount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEscCount.Location = new System.Drawing.Point(167, 20);
            this.txtEscCount.Name = "txtEscCount";
            this.txtEscCount.Size = new System.Drawing.Size(125, 29);
            this.txtEscCount.TabIndex = 0;
            this.txtEscCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_Escalation_List
            // 
            this.dataGridView_Escalation_List.AllowUserToAddRows = false;
            this.dataGridView_Escalation_List.AllowUserToResizeColumns = false;
            this.dataGridView_Escalation_List.AllowUserToResizeRows = false;
            this.dataGridView_Escalation_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Escalation_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Escalation_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Escalation_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Escalation_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Escalation_List.Location = new System.Drawing.Point(28, 297);
            this.dataGridView_Escalation_List.Name = "dataGridView_Escalation_List";
            this.dataGridView_Escalation_List.ReadOnly = true;
            this.dataGridView_Escalation_List.RowHeadersVisible = false;
            this.dataGridView_Escalation_List.RowTemplate.Height = 21;
            this.dataGridView_Escalation_List.Size = new System.Drawing.Size(687, 200);
            this.dataGridView_Escalation_List.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(30, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "エスカレ一覧";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMSPB005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 600);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_Escalation_List);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB005";
            this.Text = "MS 私物返却管理DB エスカレシート出力";
            this.Shown += new System.EventHandler(this.frmMSPB005_Shown);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Escalation_List)).EndInit();
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
        /// 加算日数
        /// </summary>
        private static readonly int _addDate = 92;    // SYSDATE - 92日
        /// <summary>
        /// 更新ステータス
        /// </summary>
        private static readonly string _status = "1";    // ステータス「1：エスカレ送付」

        daofrmMSPB005 dao = new daofrmMSPB005("DBConnection");

        // エスカレ件数用DataTable
        DataTable escCntDt = new DataTable();
        // 総出力件数用DataTable
        DataTable totalEscCntDt = new DataTable();

        #endregion

        #region データグリッドビュー用テーブル
        // <summary>
        // データグリッドビュー用 エスカレ一覧テーブル
        // </summary>
        public sealed class Escalation_List
        {
            // NO
            public string NO { get; set; }
            // 登録日
            public string REGIST_DATE { get; set; }
            // 種別
            public string PRODUCT_TYPE { get; set; }
            // 管理番号
            public string CONTROL_NO { get; set; }
            // 証券番号
            public string CONTRACT_NO { get; set; }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB005(string userName)
        {

            _logger.Info("私物返却管理DB：エスカレシート出力 開始");

            _userName = userName;

            InitializeComponent();

            // 画面上の件数、エスカレ一覧表示
            setDisplayEscalationSheet();

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion

        #region イベント

        #region Shown処理
        private void frmMSPB005_Shown(object sender, EventArgs e)
        {   
            //初期表示の選択されているセルをなくす
            dataGridView_Escalation_List.CurrentCell = null;
        }
        #endregion

        #region エスカレシート出力ボタン押下
        private void btnEscSheetOutput_Click(object sender, EventArgs e)
        {
            string outputFileList = null;

            List<clsEscalationSheetList> targetList = null;

            try 
            {
                _logger.Info("エスカレシート出力処理 開始");

                this.Cursor = Cursors.WaitCursor;

                // トランザクション開始
                dao.BeginTransaction();

                // エスカレ出力対象データ
                targetList = createOutputTargetList(totalEscCntDt);

                // エスカレシート出力
                outputFileList = new clsEscalationSheetList()
                {
                    lstEscSheetData = targetList
                }.createEscalationSheetList();

                if (!string.IsNullOrEmpty(outputFileList))
                {
                    // ｢エスカレテーブル｣｢ステータス」＝0 のデータ更新処理
                    foreach (DataRow row in escCntDt.Rows)
                    {
                        dao.Update_TrgEscSheet_T_ESCALATION(_status, DateTime.Now.ToString("yyyyMMdd"), row["CONTROL_NO"].ToString());
                    }

                    // エスカレシートのExcelファイルを開く
                    Process.Start(outputFileList);
                }

                // コミット
                dao.Commit();
            }
            catch (Exception ex)
            {   
                // ロールバック
                dao.Rollback();
                _logger.Fatal("エスカレシート出力処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("エスカレシート出力処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _logger.Info("エスカレシート出力処理 終了");
            }

            // 処理履歴テーブル登録
            if (!string.IsNullOrEmpty(outputFileList))
            {   
                setProcessHistoryTbl("エスカレシート作成", Path.GetFileName(outputFileList), targetList.Count);
            }

            // 画面上の件数、エスカレ一覧表示
            setDisplayEscalationSheet();

        }
        #endregion

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("エスカレシート出力：戻るボタン押下");
            _logger.Info("私物返却管理DB：エスカレシート出力 終了");
            this.Close();
        }
        #endregion

        #endregion

        #region メソッド

        #region 画面上の件数、エスカレ一覧表示
        private void setDisplayEscalationSheet()
        {
            try
            {
                _logger.Info("エスカレシート出力対象データ取得、画面項目表示 開始");

                // エスカレ件数取得
                escCntDt = dao.Select_T_ESCALATION();

                if (escCntDt.Rows.Count <= 0)
                {
                    _logger.Info("エスカレ件数：エスカレテーブルにはエスカレ件数の対象データが存在しません。");
                }
                else
                {
                    _logger.Info($"エスカレ件数：[{escCntDt.Rows.Count}]");
                }

                // 総出力件数取得
                totalEscCntDt = dao.Select_TotalOutputCount_T_ESCALATION(_addDate);
                
                _logger.Info($"総出力件数　：[{totalEscCntDt.Rows.Count}]");

                this.txtEscCount.Text = escCntDt.Rows.Count.ToString("#,0");
                this.txtTotalOutputCnt.Text = totalEscCntDt.Rows.Count.ToString("#,0");

                // エスカレ一覧表示
                setDisplayGridViewEscalationList(escCntDt);

            }
            catch(Exception ex)
            {
                _logger.Fatal("エスカレシート出力画面表示対象データ取得処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("エスカレシート出力画面表示対象データ取得処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
            }
            finally
            {
                _logger.Info("エスカレシート出力対象データ取得、画面項目表示 終了");
            }
        }
        #endregion

        #region エスカレ一覧表示
        private void setDisplayGridViewEscalationList(DataTable dt)
        {

            List<Escalation_List> dtos = new List<Escalation_List>();
            dtos.Clear();

            _logger.Debug("エスカレ一覧GridViewバインド 開始");

            if (dt.Rows.Count <= 0)
            {
                //空のデータグリッドビューを表示する
                //データグリッドビューのクリア
                dataGridView_Escalation_List.DataSource = null;
                //Packing_LineのリストをDataGridViewにデータバインドする
                dataGridView_Escalation_List.DataSource = dtos;
            }

            int dataCnt = 0;

            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach(DataRow row in dt.Rows)
            {
                dataCnt += 1;

                var date = row["REGIST_DATE"].ToString().Insert(6, "/").Insert(4, "/");

                _logger.Info($"エスカレ一覧表示対象_管理番号：[{row["CONTROL_NO"].ToString()}]");

                //検索結果を項目ごとにPacking_Lineに格納する
                Escalation_List dto = new Escalation_List();
                dto.NO = dataCnt.ToString("#,0");
                dto.REGIST_DATE = date;
                dto.PRODUCT_TYPE = row["PRODUCT_TYPE"].ToString();
                dto.CONTROL_NO = row["CONTROL_NO"].ToString();
                dto.CONTRACT_NO = row["CONTRACT_NO"].ToString();                
                dtos.Add(dto);
            }

            //Packing_LineのリストをDataGridViewにデータバインドする
            dataGridView_Escalation_List.DataSource = dtos;

            //データグリッドのタイトル設定
            dataGridView_Escalation_List.Columns[0].HeaderText = "NO";
            dataGridView_Escalation_List.Columns[1].HeaderText = "登録日";
            dataGridView_Escalation_List.Columns[2].HeaderText = "種別";
            dataGridView_Escalation_List.Columns[3].HeaderText = "管理番号";
            dataGridView_Escalation_List.Columns[4].HeaderText = "証券番号";            

            //更新禁止
            dataGridView_Escalation_List.Columns[0].ReadOnly = true;
            dataGridView_Escalation_List.Columns[1].ReadOnly = true;
            dataGridView_Escalation_List.Columns[2].ReadOnly = true;
            dataGridView_Escalation_List.Columns[3].ReadOnly = true;
            dataGridView_Escalation_List.Columns[4].ReadOnly = true;            

            //初期表示の選択されているセルをなくす
            dataGridView_Escalation_List.CurrentCell = null;

            //ヘッダテキストの文字列の折り返しを抑止
            dataGridView_Escalation_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            //ヘッダテキストの文字配置はセル内センター
            dataGridView_Escalation_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
            foreach (DataGridViewColumn c in dataGridView_Escalation_List.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //列の自動設定を抑止
            dataGridView_Escalation_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //各列の幅を設定
            dataGridView_Escalation_List.Columns[0].Width = 65;
            dataGridView_Escalation_List.Columns[1].Width = 100;
            dataGridView_Escalation_List.Columns[2].Width = 110;
            dataGridView_Escalation_List.Columns[3].Width = 185;
            dataGridView_Escalation_List.Columns[4].Width = 207;            

            //文字サイスを設定
            dataGridView_Escalation_List.Font = new Font("メイリオ", 9.5F);

            //列のセルのテキストの配置を上下左右とも中央にする
            dataGridView_Escalation_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Escalation_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Escalation_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Escalation_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Escalation_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            

            // 選択モードを行単位での選択のみにする
            dataGridView_Escalation_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //DataGridView1でセル、行、列が複数選択されないようにする
            dataGridView_Escalation_List.MultiSelect = false;

            _logger.Debug("エスカレ一覧GridViewバインド 終了");

        }
        #endregion

        #region エスカレ出力対象データ
        private List<clsEscalationSheetList> createOutputTargetList(DataTable dt)
        {
            List<clsEscalationSheetList> lstData = new List<clsEscalationSheetList>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    clsEscalationSheetList trgData = new clsEscalationSheetList
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        REGIST_DATE = row["REGIST_DATE"].ToString(),
                        PRODUCT_TYPE = row["PRODUCT_TYPE"].ToString(),
                        CONTROL_NO = row["CONTROL_NO"].ToString(),
                        CONTRACT_NO = row["CONTRACT_NO"].ToString(),
                        PERSONAL_BELONGINGS_INFO = row["PERSONAL_BELONGINGS_INFO"].ToString(),
                        STATUS = row["ESCALATION_LABEL"].ToString(),
                        MS_RETURN_FLAG = row["MS_RETURN_FLAG"].ToString(),
                        SHIPPING_DATE = row["SHIPPING_DATE"].ToString()
                    };

                    lstData.Add(trgData);
                }
            }

            // ID降順
            return lstData.OrderByDescending(x => x.ID).ToList();
        }
        #endregion

        #region 処理履歴登録
        /// <summary>
        /// 処理履歴登録
        /// </summary>
        /// <param name="fileList"></param>
        private void setProcessHistoryTbl(string processText, string outFileName, int outCount)
        {
            _logger.Info("処理履歴登録 開始");

            try
            {
                // トランザクション開始
                dao.BeginTransaction();

                int maxSeqNo = dao.Select_MaxSeqNo_T_PROCESS_HISTORY();

                _logger.Debug($"T_PROCESS_HISTORYのMAX SEQ_NO：[{maxSeqNo}]");
                
                ProcessHistoryEnity entity = new ProcessHistoryEnity()
                {
                    SEQ_NO = maxSeqNo + 1,
                    PROCESS_TEXT = processText,
                    OUTPUT_FILE_NAME = Path.GetFileName(outFileName),
                    OUTPUT_COUNT = outCount,
                    UPDATE_USER = _userName
                };

                dao.Insert_T_PROCESS_HISTORY(entity);
                
                // コミット
                dao.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック
                dao.Rollback();
                _logger.Fatal("処理履歴登録処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("処理履歴登録でエラーが発生しました。" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }
            finally
            {
                _logger.Info("処理履歴登録 終了");
            }
        }
        #endregion

        #endregion

    }
}
