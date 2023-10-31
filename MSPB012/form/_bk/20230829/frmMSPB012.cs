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

namespace MSPB.MSPB012.form
{

    /// <summary>
    /// 検索詳細画面
    /// </summary>
    class frmMSPB012 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_Search_List;        
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colLoginId;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewTextBoxColumn colAuthority;
        private System.Windows.Forms.Label header0;


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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Search_List = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Search_List)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(10, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(666, 100);
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
            this.header0.Location = new System.Drawing.Point(194, 14);
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
            this.header1.Location = new System.Drawing.Point(247, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(123, 24);
            this.header1.TabIndex = 0;
            this.header1.Text = "ユーザ管理";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(36, 676);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_Search_List);
            this.panel2.Location = new System.Drawing.Point(12, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 536);
            this.panel2.TabIndex = 93;
            // 
            // dataGridView_Search_List
            // 
            this.dataGridView_Search_List.AllowUserToAddRows = false;
            this.dataGridView_Search_List.AllowUserToResizeColumns = false;
            this.dataGridView_Search_List.AllowUserToResizeRows = false;
            this.dataGridView_Search_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Search_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Search_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Search_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Search_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colLoginId,
            this.colUserName,
            this.colAuthority});
            this.dataGridView_Search_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Search_List.Location = new System.Drawing.Point(24, 13);
            this.dataGridView_Search_List.Name = "dataGridView_Search_List";
            this.dataGridView_Search_List.ReadOnly = true;
            this.dataGridView_Search_List.RowHeadersVisible = false;
            this.dataGridView_Search_List.RowTemplate.Height = 21;
            this.dataGridView_Search_List.Size = new System.Drawing.Size(426, 493);
            this.dataGridView_Search_List.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(386, 676);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 31);
            this.button1.TabIndex = 94;
            this.button1.Text = "エクスポート";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(533, 676);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 31);
            this.button2.TabIndex = 95;
            this.button2.Text = "インポート";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // colNo
            // 
            this.colNo.FillWeight = 40F;
            this.colNo.HeaderText = "NO";
            this.colNo.MinimumWidth = 40;
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colLoginId
            // 
            this.colLoginId.FillWeight = 150F;
            this.colLoginId.HeaderText = "ログインID";
            this.colLoginId.MinimumWidth = 150;
            this.colLoginId.Name = "colLoginId";
            this.colLoginId.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.FillWeight = 130F;
            this.colUserName.HeaderText = "名前";
            this.colUserName.MinimumWidth = 130;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colAuthority
            // 
            this.colAuthority.HeaderText = "権限";
            this.colAuthority.MinimumWidth = 100;
            this.colAuthority.Name = "colAuthority";
            this.colAuthority.ReadOnly = true;
            // 
            // frmMSPB012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(687, 736);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB012";
            this.Text = "MS 私物返却管理DB ユーザ管理";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.Load += new System.EventHandler(this.MSPB012_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Search_List)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region 変数
        /// <summary>
        /// ログ
        /// </summary>
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataTable dt = null;

        List<Employee_tmp> dtos = new List<Employee_tmp>();
        

        #endregion
        #region コンストラクタ
        // <summary>
        // データグリッドビュー用 担当者テーブル
        // </summary>
        public sealed class Employee_tmp
        {
            public string ID { get; set; }
            public string USER_ID { get; set; }
            public string USER_NAME { get; set; }
            public string AUTHORITY { get; set; }
            //public string USER_PASSWORD { get; set; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB012()
        {
            _logger.Info("ユーザ管理処理：開始");
            InitializeComponent();            

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

        }
        #endregion
        #region イベント
        private void MSPB012_Load(object sender, EventArgs e)
        {
            using (var dao = new dao.daofrmMSPB012("DBConnection"))
            {
                dt = dao.select_Employee();
            }
            _logger.Info("ユーザ管理テーブル取得数 [" + dt.Rows.Count + "]");

            int data_count = 0;
            if (dt.Rows.Count <= 0)
            {
                _logger.Info("ユーザ管理テーブルにデータが存在しません。");

            }
            else
            {
                dtos.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //検索結果を項目ごとにPacking_Lineに格納する
                    Employee_tmp dto = new Employee_tmp();
                    dto.ID = dt.Rows[i]["ID"].ToString();
                    dto.USER_ID = dt.Rows[i]["USER_ID"].ToString();
                    dto.USER_NAME = dt.Rows[i]["USER_NAME"].ToString();
                    dto.AUTHORITY = dt.Rows[i]["USER_AUTHORITY"].ToString();
                    //dto.USER_PASSWORD = dt.Rows[i]["USER_PASSWORD"].ToString();
                    dtos.Add(dto);
                    data_count++;
                }
                //Packing_LineのリストをDataGridViewにデータバインドする
                dataGridView_Search_List.DataSource = dtos;
                /*
                //データグリッドのタイトル設定
                dataGridView_Search_List.Columns[0].HeaderText = "ID";
                dataGridView_Search_List.Columns[1].HeaderText = "ログインID";
                dataGridView_Search_List.Columns[2].HeaderText = "名前";
                dataGridView_Search_List.Columns[3].HeaderText = "権限";
                dataGridView_Search_List.Columns[4].HeaderText = "パスワード";

                //更新禁止
                dataGridView_Search_List.Columns[0].ReadOnly = true;
                dataGridView_Search_List.Columns[1].ReadOnly = true;
                dataGridView_Search_List.Columns[2].ReadOnly = true;
                dataGridView_Search_List.Columns[3].ReadOnly = true;
                dataGridView_Search_List.Columns[4].ReadOnly = true;

                //初期表示の選択されているセルをなくす
                dataGridView_Search_List.CurrentCell = null;

                //ヘッダテキストの文字列の折り返しを抑止
                dataGridView_Search_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                //ヘッダテキストの文字配置はセル内センター
                dataGridView_Search_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
                foreach (DataGridViewColumn c in dataGridView_Search_List.Columns)
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;

                //列の自動設定を抑止
                dataGridView_Search_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                //各列の幅を設定
                dataGridView_Search_List.Columns[0].Width = 50;
                dataGridView_Search_List.Columns[1].Width = 130;
                dataGridView_Search_List.Columns[2].Width = 130;
                dataGridView_Search_List.Columns[3].Width = 130;
                dataGridView_Search_List.Columns[4].Width = 130;

                //文字サイスを設定
                dataGridView_Search_List.Font = new Font(dataGridView_Search_List.Font.Name, 10);

                //列のセルのテキストの配置を上下左右とも中央にする
                dataGridView_Search_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Search_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Search_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Search_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Search_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 選択モードを行単位での選択のみにする
                dataGridView_Search_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //DataGridViewでセル、行、列が複数選択されないようにする
                dataGridView_Search_List.MultiSelect = false;
                */
            }
        }

        #region 戻るボタン押下
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Info("ユーザ管理：戻るボタン押下");
            _logger.Info("ユーザ管理処理：終了");
            this.Close();
        }
        #endregion

        #endregion

    }
}
