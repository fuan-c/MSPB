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
using System.Data;
using MSPB.MSPB004.dao;
using MSPB.MSPB004.pdf;
using MSPB.MSPB004.logic;
using MSPB.MSPB004.common;
using System.IO;

namespace MSPB.MSPB004.form
{

    /// <summary>
    /// 出荷処理画面
    /// </summary>
    class frmMSPB004 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Label header0;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboShippingDate;
        private System.Windows.Forms.DataGridView dataGridView_Shipping_List;
        private Button btnShippingDisplay;
        private Button btnShippingDataOutput;
        private System.Windows.Forms.Label label1;


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
            this.btnShippingDisplay = new System.Windows.Forms.Button();
            this.btnShippingDataOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboShippingDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Shipping_List = new System.Windows.Forms.DataGridView();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Shipping_List)).BeginInit();
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
            this.header1.Location = new System.Drawing.Point(297, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(111, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "出荷処理";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(571, 536);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShippingDisplay);
            this.panel1.Controls.Add(this.btnShippingDataOutput);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboShippingDate);
            this.panel1.Location = new System.Drawing.Point(8, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 156);
            this.panel1.TabIndex = 0;
            // 
            // btnShippingDisplay
            // 
            this.btnShippingDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShippingDisplay.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShippingDisplay.Location = new System.Drawing.Point(336, 50);
            this.btnShippingDisplay.Name = "btnShippingDisplay";
            this.btnShippingDisplay.Size = new System.Drawing.Size(130, 33);
            this.btnShippingDisplay.TabIndex = 1;
            this.btnShippingDisplay.Text = "出荷表示";
            this.btnShippingDisplay.UseVisualStyleBackColor = true;
            this.btnShippingDisplay.Click += new System.EventHandler(this.btnShippingDisplay_Click);
            // 
            // btnShippingDataOutput
            // 
            this.btnShippingDataOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShippingDataOutput.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShippingDataOutput.Location = new System.Drawing.Point(336, 104);
            this.btnShippingDataOutput.Name = "btnShippingDataOutput";
            this.btnShippingDataOutput.Size = new System.Drawing.Size(181, 33);
            this.btnShippingDataOutput.TabIndex = 2;
            this.btnShippingDataOutput.Text = "発送出荷データ出力";
            this.btnShippingDataOutput.UseVisualStyleBackColor = true;
            this.btnShippingDataOutput.Click += new System.EventHandler(this.btnShippingDataOutput_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(62, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "出荷指定日";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboShippingDate
            // 
            this.comboShippingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboShippingDate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboShippingDate.Location = new System.Drawing.Point(65, 50);
            this.comboShippingDate.Name = "comboShippingDate";
            this.comboShippingDate.Size = new System.Drawing.Size(122, 32);
            this.comboShippingDate.TabIndex = 0;
            this.comboShippingDate.SelectedIndexChanged += new System.EventHandler(this.Combobox_Shipping_Date_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(54, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "出荷一覧";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView_Shipping_List
            // 
            this.dataGridView_Shipping_List.AllowUserToAddRows = false;
            this.dataGridView_Shipping_List.AllowUserToResizeColumns = false;
            this.dataGridView_Shipping_List.AllowUserToResizeRows = false;
            this.dataGridView_Shipping_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Shipping_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Shipping_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Shipping_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Shipping_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Shipping_List.Location = new System.Drawing.Point(52, 307);
            this.dataGridView_Shipping_List.Name = "dataGridView_Shipping_List";
            this.dataGridView_Shipping_List.ReadOnly = true;
            this.dataGridView_Shipping_List.RowHeadersVisible = false;
            this.dataGridView_Shipping_List.RowTemplate.Height = 21;
            this.dataGridView_Shipping_List.Size = new System.Drawing.Size(573, 198);
            this.dataGridView_Shipping_List.TabIndex = 4;
            // 
            // frmMSPB004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Shipping_List);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB004";
            this.Text = "MS 私物返却管理DB 出荷処理";
            this.Load += new System.EventHandler(this.frmMSPB004_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Shipping_List)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 会社情報
        /// </summary>
        private clsCompany CompanyInfo;
        /// <summary>
        /// 出荷日保持用
        /// </summary>
        private static string _shippingDate = string.Empty;
        /// <summary>
        /// ユーザ名
        /// </summary>
        private static string _userName = string.Empty;

        daofrmMSPB004 dao = new daofrmMSPB004("DBConnection");

        DataTable dtShipping = new DataTable();

        #endregion

        // <summary>
        // データグリッドビュー用 出荷一覧テーブル
        // </summary>
        public sealed class Shipping_List
        {
            // ID
            public string ID { get; set; }
            // 出荷日
            public string SHIPPING_DATE { get; set; }
            // 返却先
            public string RETURN_PLACE { get; set; }
            // 返却先名
            public string RETURN_PLACE_NAME { get; set; }
            // 件数
            public string PACKING_COUNT { get; set; }
            // 梱包ステータス
            public string PACKING_STATUS { get; set; }            
        }

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB004(string userName)
        {
            _userName = userName;
            _shippingDate = null;

            InitializeComponent();
            
            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            // 出荷日指定プルダウン設定
            setComboBoxShippingDate();
            // 出荷一覧表示
            displayGridviewShippingList(_shippingDate);

        }
        #endregion

        #region イベント

        #region Form_Load
        /// <summary>
        /// Form_Load
        /// </summary>
        /// <remarks></remarks>
        private void frmMSPB004_Load(object sender, EventArgs e)
        {
            // 初期値(未選択状態)            
            comboShippingDate.SelectedIndex = -1;
        }
        #endregion

        #region 出荷指定日プルダウン処理
        /// <summary>
        /// 出荷指定日プルダウン処理
        /// </summary>
        /// <remarks></remarks>
        private void Combobox_Shipping_Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboShippingDate.SelectedIndex != -1)
            {
                _shippingDate = comboShippingDate.SelectedItem.ToString();
            }
            else
            {
                _shippingDate = null;
            }
        }
        #endregion

        #region 戻るボタン押下
        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("出荷処理：戻るボタン押下");
            this.Close();
        }
        #endregion

        #region 出荷表示ボタン押下
        /// <summary>
        /// 出荷表示ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void btnShippingDisplay_Click(object sender, EventArgs e)
        {
            //出荷日入力チェック
            if (string.IsNullOrEmpty(_shippingDate))
            {
                _logger.Info("出荷日が指定されていません。出荷日を指定してください。");
                new clsMessageBox().MessageBoxOKOnly("出荷日が指定されていません。" + Environment.NewLine + "出荷日をし指定してください。", "警告", MessageBoxIcon.Exclamation);
                this.ActiveControl = this.comboShippingDate;
                return;
            }

            // 出荷一覧表示
            displayGridviewShippingList(_shippingDate);
        }
        #endregion

        #region 発送出荷データ出力ボタン押下
        /// <summary>
        /// 発送出荷データ出力ボタン押下
        /// </summary>
        /// <remarks></remarks>
        private void btnShippingDataOutput_Click(object sender, EventArgs e)
        {
            _logger.Info("発送出荷データ出力ボタン押下");
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (string.IsNullOrEmpty(_shippingDate))
                {
                    _logger.Debug("出荷日が選択されていません。");
                    new clsMessageBox().MessageBoxOKOnly("出荷日を選択して下さい。", "警告", MessageBoxIcon.Warning);                    
                    return;
                }

                //データ取得
                var lstRowData = dataGridView_Shipping_List.Rows.Cast<DataGridViewRow>().ToList();

                if (lstRowData.Count <= 0)
                {                    
                    new clsMessageBox().MessageBoxOKOnly("発送出荷対象が存在しません。", "警告", MessageBoxIcon.Warning);
                    return;
                }
                if (lstRowData.Where(x => x.Cells[5].Value.ToString() == "完了").Count() != lstRowData.Count)
                {
                    new clsMessageBox().MessageBoxOKOnly("作業中です", "警告", MessageBoxIcon.Warning);                    
                    return;
                }
                
                // 発送QMSデータより契約者返却帳票出力対象データ取得
                var dtQms = dao.Select_ShippingDate_T_MS_SHIPPING_QMS(_shippingDate);

                // ゆうパック差出票対象データ取得
                List<clsYupackSendingSlipRecord> lstYupackSendingSlipData = getYupackSendingSlipData(dtQms);

                string yuPackChekFile = string.Empty;

                if (dtQms.Rows.Count > 0)
                {
                    // ゆうパック差出票作成
                    yuPackChekFile = new clsYupackSendingSlip()
                    {
                        lstYupackSendingSlipData = lstYupackSendingSlipData,
                        SHIPPING_DATE = _shippingDate
                    }.CreateYupackSendingSlip(ConfigurationManager.AppSettings["MSPB003_SLIP_MS_RETURN_HEADER"]);


                    var shippingCmpDate = DateTime.Now.ToString("yyyyMMdd");

                    // 対象データのDB更新処理
                    updateContractorRtnTBL(shippingCmpDate, _shippingDate, dtShipping, dtQms);

                    // 処理履歴更新
                    setProcessHistoryTbl("ゆうメール差出票", Path.GetFileName(yuPackChekFile), dtQms.Rows.Count);

                    // 印刷画面を表示する
                    new comPdfFile().pdfPrintOpen(yuPackChekFile);

                    // 出荷日指定プルダウン設定
                    setComboBoxShippingDate();

                    // 出荷一覧再表示
                    displayGridviewShippingList(_shippingDate);

                }
            }
            catch (Exception ex)
            {
                if (ex is InnerException){}
                else
                {
                    _logger.Fatal("ゆうパック差出票作成にて異常終了しました。");
                    _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                    new clsMessageBox().MessageBoxOKOnly("ゆうパック差出票作成にて異常終了しました。", "異常終了", MessageBoxIcon.Exclamation);
                }
                
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion

        #region メソッド

        #region 出荷日指定プルダウン設定
        /// <summary>
        /// 出荷日指定プルダウン設定
        /// </summary>
        /// <remarks></remarks>
        private void setComboBoxShippingDate()
        {
            try
            {
                // 梱包ラインテーブルより出荷日取得
                DataTable dt = dao.Select_ShippingDate_T_MS_PACKING_LINE();

                _logger.Info("出荷日取得件数 [" + dt.Rows.Count + "]");

                comboShippingDate.Items.Clear();

                // 出荷日のプルダウン設定
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboShippingDate.Items.Add(dt.Rows[i]["SHIPPING_DATE"].ToString());
                }

                comboShippingDate.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                _logger.Fatal("梱包ラインテーブルより出荷日取得取得でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("梱包ラインテーブルより出荷日取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 出荷一覧表示処理
        /// <summary>
        /// 出荷一覧表示処理
        /// </summary>
        /// <remarks></remarks>
        private void displayGridviewShippingList(string shippingDate)
        {
            List<Shipping_List> dtos = new List<Shipping_List>();
            dtos.Clear();

            try
            {
                if (!string.IsNullOrEmpty(shippingDate))
                {
                    dtShipping = dao.Select_TrgShippingData_T_MS_PACKING_LINE(shippingDate);
                }

                _logger.Info("出荷一覧取得件数 [" + dtShipping.Rows.Count + "]");

                if (dtShipping.Rows.Count <= 0)
                {
                    _logger.Info("対象データが梱包ラインテーブルに存在しません。");

                    //空のデータグリッドビューを表示する
                    //データグリッドビューのクリア
                    dataGridView_Shipping_List.DataSource = null;
                    //Packing_LineのリストをDataGridViewにデータバインドする
                    dataGridView_Shipping_List.DataSource = dtos;
                }
                
                for (int i = 0; i < dtShipping.Rows.Count; i++)
                {
                    //検索結果を項目ごとにPacking_Lineに格納する
                    Shipping_List dto = new Shipping_List();
                    dto.ID = dtShipping.Rows[i]["ID"].ToString();
                    dto.SHIPPING_DATE = dtShipping.Rows[i]["SHIPPING_DATE"].ToString();
                    dto.RETURN_PLACE = dtShipping.Rows[i]["RETURN_PLACE"].ToString();
                    dto.RETURN_PLACE_NAME = dtShipping.Rows[i]["RESPONSE_TEXT"].ToString();
                    dto.PACKING_COUNT = dtShipping.Rows[i]["PACKING_COUNT"].ToString();
                    dto.PACKING_STATUS = dtShipping.Rows[i]["PACKING_STATUS"].ToString();                    
                    dtos.Add(dto);
                }

                //Packing_LineのリストをDataGridViewにデータバインドする
                dataGridView_Shipping_List.DataSource = dtos;

                //データグリッドのタイトル設定
                dataGridView_Shipping_List.Columns[0].HeaderText = "ID";
                dataGridView_Shipping_List.Columns[1].HeaderText = "出荷日";
                dataGridView_Shipping_List.Columns[2].HeaderText = "返却先_CD";
                dataGridView_Shipping_List.Columns[3].HeaderText = "返却先";
                dataGridView_Shipping_List.Columns[4].HeaderText = "件数";                
                dataGridView_Shipping_List.Columns[5].HeaderText = "梱包";

                //更新禁止
                dataGridView_Shipping_List.Columns[0].ReadOnly = true;
                dataGridView_Shipping_List.Columns[1].ReadOnly = true;
                dataGridView_Shipping_List.Columns[2].ReadOnly = true;
                dataGridView_Shipping_List.Columns[3].ReadOnly = true;
                dataGridView_Shipping_List.Columns[4].ReadOnly = true;
                dataGridView_Shipping_List.Columns[5].ReadOnly = true;                

                //初期表示の選択されているセルをなくす
                dataGridView_Shipping_List.CurrentCell = null;

                //ヘッダテキストの文字列の折り返しを抑止
                dataGridView_Shipping_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                //ヘッダテキストの文字配置はセル内センター
                dataGridView_Shipping_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
                foreach (DataGridViewColumn c in dataGridView_Shipping_List.Columns)
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;

                //列の自動設定を抑止
                dataGridView_Shipping_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                //各列の幅を設定
                dataGridView_Shipping_List.Columns[0].Width = 73;
                dataGridView_Shipping_List.Columns[1].Width = 150;
                dataGridView_Shipping_List.Columns[2].Width = 140;
                dataGridView_Shipping_List.Columns[3].Width = 140;
                dataGridView_Shipping_List.Columns[4].Width = 90;
                dataGridView_Shipping_List.Columns[5].Width = 100;
                
                //文字サイスを設定
                dataGridView_Shipping_List.Font = new Font("メイリオ", 10);

                //列のセルのテキストの配置を上下左右とも中央にする
                dataGridView_Shipping_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Shipping_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Shipping_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Shipping_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Shipping_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Shipping_List.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                //返却先CDを非表示
                dataGridView_Shipping_List.Columns[2].Visible = false;

                // 選択モードを行単位での選択のみにする
                dataGridView_Shipping_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //DataGridView1でセル、行、列が複数選択されないようにする
                dataGridView_Shipping_List.MultiSelect = false;
                                
            }
            catch (Exception ex)
            {
                _logger.Fatal("出荷一覧表示処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("出荷一覧表示処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);
                return;
            }
        }

        #endregion

        #region ゆうパック差出票対象データ取得
        /// <summary>
        /// ゆうパック差出票対象データ取得
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private List<clsYupackSendingSlipRecord> getYupackSendingSlipData(DataTable dt)
        {
            _logger.Debug("ゆうパック差出票対象データ取得取得");

            //会社情報取得
            this.CompanyInfo = getCompanyInfo();

            // ユパケット対象データ保持用リスト
            List<clsYupackSendingSlipRecord> lstData = new List<clsYupackSendingSlipRecord>();

            // 契約者返却データが存在する場合
            if (dt.Rows.Count > 0)
            {
                int cntID = 0;
                foreach (DataRow row in dt.Rows)
                {
                    clsYupackSendingSlipRecord trgData = new clsYupackSendingSlipRecord
                    {
                        //ID = (int)row["ID"],
                        ID = cntID++,
                        SEND_DEST_NAME = (string)row["SEND_DEST_NAME"],
                        SEND_DEST_POSTAL_CODE = (string)row["SEND_DEST_POSTAL_CODE"],
                        SEND_DEST_ADDRESS = (string)row["SEND_DEST_ADDRESS"],
                        CONTACT_NO = (string)row["CONTACT_NO"],
                        SHIPPING_DATE = (string)row["SHIPPING_DATE"],
                        COMPANY_FORMAL_NAME = this.CompanyInfo.FORMAL_NAME,
                        YUPACK_CUSTOMER_NO = this.CompanyInfo.YUPACK_CUSTOMER_NO
                    };

                    lstData.Add(trgData);
                }
            }

            _logger.Info($"ゆうパック差出票対象データ件数：[{lstData.Count}]");

            return lstData;

        }
        #endregion

        #region 会社情報取得
        /// <summary>
        /// 会社情報取得
        /// </summary>
        /// <returns></returns>
        private clsCompany getCompanyInfo()
        {
            _logger.Debug("会社情報取得");
            clsCompany Company;

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
        #endregion

        #region 対象データのDB更新処理
        /// <summary>
        /// 対象データのDB更新処理
        /// </summary>
        /// <returns></returns>
        private void updateContractorRtnTBL(string shippingCmpDate, string shippingDate, DataTable dtShippingLine, DataTable dtQms)
        {
            _logger.Info("対象データのDB更新処理：開始");

            try
            {

                dao.BeginTransaction();

                // 梱包ラインテーブルに契約者返却データ更新処理
                foreach (DataRow row in dtShippingLine.Rows)
                {
                    dao.Update_ContractorRtn_T_MS_PACKING_LINE(shippingCmpDate, row["ID"].ToString());
                }

                // 梱包ラインテーブルに契約者返却データ更新処理
                dao.Update_ContractorRtn_T_MS_SHIPPING_QMS(shippingCmpDate, shippingDate);

                // エスカレテーブルに契約者返却データ更新処理
                foreach (DataRow row in dtQms.Rows)
                {
                    dao.Update_ContractorRtn_T_ESCALATION("6", row["CONTACT_NO"].ToString(), row["CONTROL_NO"].ToString());     // ステータス「6:返却済」
                }

                dao.Commit();
            }
            catch (Exception ex)
            {
                // ロールバック
                dao.Rollback();
                _logger.Fatal("対象データのDB更新処理でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("対象データのDB更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                throw new InnerException();
            }
            finally
            {
                _logger.Info("対象データのDB更新処理：終了");
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
                    OUTPUT_FILE_NAME = outFileName,
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
                throw new InnerException();
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
