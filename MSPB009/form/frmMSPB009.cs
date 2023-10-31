using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using MSPB.Common;
using MSPB.MSPB009.dao;
using System.Drawing;
using System.Data;

namespace MSPB.MSPB009.form
{

    /// <summary>
    /// エスカレ回答承認画面
    /// </summary>
    class frmMSPB009 : Form
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
        private System.Windows.Forms.Label lblConfirmedCnt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblContractRTNCnt;
        private System.Windows.Forms.Button btnCancel;
        private Label label6;
        private Button btnCheckAll;       
        private Button btnApproval;
        private DataGridView dataGridView_Approval_List;
        private Label label7;
        private Label label8;
        private Label label9;
        private System.Windows.Forms.Panel panel1;


        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblConfirmedCnt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblContractRTNCnt = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_Approval_List = new System.Windows.Forms.DataGridView();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApproval = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Approval_List)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.header0);
            this.panelTitle.Controls.Add(this.header1);
            this.panelTitle.Location = new System.Drawing.Point(19, 4);
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
            this.header1.Location = new System.Drawing.Point(258, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(207, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "エスカレ回答承認";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(72, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "契約者返却";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(229, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "MS返却";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(386, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "MS返却（超過）";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(547, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "承認済";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 26);
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
            this.lblMSRTNCnt.Location = new System.Drawing.Point(229, 32);
            this.lblMSRTNCnt.Name = "lblMSRTNCnt";
            this.lblMSRTNCnt.Size = new System.Drawing.Size(151, 23);
            this.lblMSRTNCnt.TabIndex = 0;
            this.lblMSRTNCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMSRTNOverCnt
            // 
            this.lblMSRTNOverCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMSRTNOverCnt.BackColor = System.Drawing.Color.White;
            this.lblMSRTNOverCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMSRTNOverCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMSRTNOverCnt.Location = new System.Drawing.Point(386, 32);
            this.lblMSRTNOverCnt.Name = "lblMSRTNOverCnt";
            this.lblMSRTNOverCnt.Size = new System.Drawing.Size(151, 23);
            this.lblMSRTNOverCnt.TabIndex = 0;
            this.lblMSRTNOverCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmedCnt
            // 
            this.lblConfirmedCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmedCnt.BackColor = System.Drawing.Color.White;
            this.lblConfirmedCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConfirmedCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConfirmedCnt.Location = new System.Drawing.Point(543, 32);
            this.lblConfirmedCnt.Name = "lblConfirmedCnt";
            this.lblConfirmedCnt.Size = new System.Drawing.Size(151, 23);
            this.lblConfirmedCnt.TabIndex = 0;
            this.lblConfirmedCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmedCnt, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblContractRTNCnt
            // 
            this.lblContractRTNCnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContractRTNCnt.BackColor = System.Drawing.Color.White;
            this.lblContractRTNCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContractRTNCnt.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContractRTNCnt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblContractRTNCnt.Location = new System.Drawing.Point(72, 32);
            this.lblContractRTNCnt.Name = "lblContractRTNCnt";
            this.lblContractRTNCnt.Size = new System.Drawing.Size(151, 23);
            this.lblContractRTNCnt.TabIndex = 0;
            this.lblContractRTNCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(39, 547);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "戻る";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_Approval_List);
            this.panel1.Controls.Add(this.btnCheckAll);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(10, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 325);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView_Approval_List
            // 
            this.dataGridView_Approval_List.AllowUserToAddRows = false;
            this.dataGridView_Approval_List.AllowUserToDeleteRows = false;
            this.dataGridView_Approval_List.AllowUserToResizeColumns = false;
            this.dataGridView_Approval_List.AllowUserToResizeRows = false;
            this.dataGridView_Approval_List.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Approval_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Approval_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Approval_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Approval_List.EnableHeadersVisualStyles = false;
            this.dataGridView_Approval_List.Location = new System.Drawing.Point(2, 92);
            this.dataGridView_Approval_List.Name = "dataGridView_Approval_List";
            this.dataGridView_Approval_List.RowHeadersVisible = false;
            this.dataGridView_Approval_List.RowTemplate.Height = 21;
            this.dataGridView_Approval_List.Size = new System.Drawing.Size(747, 230);
            this.dataGridView_Approval_List.TabIndex = 2;
            this.dataGridView_Approval_List.TabStop = false;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckAll.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheckAll.Location = new System.Drawing.Point(15, 53);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(252, 31);
            this.btnCheckAll.TabIndex = 1;
            this.btnCheckAll.TabStop = false;
            this.btnCheckAll.Text = "一括チェック（ON/OFF）";
            this.btnCheckAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAllClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "未承認一覧";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApproval
            // 
            this.btnApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApproval.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnApproval.Location = new System.Drawing.Point(613, 547);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(110, 31);
            this.btnApproval.TabIndex = 4;
            this.btnApproval.Text = "承認";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApprovalClick);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(107, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "未承認";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(264, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "未承認";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label9.Location = new System.Drawing.Point(417, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 29);
            this.label9.TabIndex = 7;
            this.label9.Text = "未承認";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmMSPB009
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(768, 600);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnApproval);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB009";
            this.Text = "MS 私物返却管理DB エスカレ回答承認";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Approval_List)).EndInit();
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
        private static string _userName;

        daofrmMSPB009 dao = null;
        DataTable dtNonApproved = null;
        DataTable dtEscalationResponse = null;
        private List<EscalationEntity> dtos = new List<EscalationEntity>();

        private readonly DateTime now = DateTime.Now;

        #endregion
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB009(string userName)
        {
            _logger.Info("私物返却管理DB：エスカレ回答承認 開始");

            _userName = userName;
            dao = new daofrmMSPB009("DBConnection", _userName);

            InitializeComponent();

            this.ActiveControl = this.dataGridView_Approval_List;

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);

            // 画面上の承認対象件数設定
            setApprovalCntDisplay();
        }
        #endregion

        #region イベント

        #region 承認ボタン押下
        private void btnApprovalClick(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答承認：承認ボタン押下");

            // 未承認一覧にて選択された承認対象保持用List
            List<EscalationEntity> approvalTargetList = new List<EscalationEntity>();

            // 未承認一覧にて選択された承認対象を保持用Listに追加
            foreach (DataGridViewRow row in dataGridView_Approval_List.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    _logger.Info("未承認一覧にて選択された管理番号：[" + row.Cells[4].Value.ToString() + "]");

                    EscalationEntity esEntity = new EscalationEntity
                    {
                        CONTROL_NO = row.Cells[4].Value.ToString(),
                        STATUS = row.Cells[7].Value.ToString()
                    };

                    approvalTargetList.Add(esEntity);
                }
            }

            _logger.Info("未承認一覧にて選択された管理番号件数 [" + approvalTargetList.Count + "]");

            DialogResult result = new clsMessageBox().MessageBoxYesNo("承認処理を行います。", "エスカレ回答承認", MessageBoxIcon.Information);
            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {

                int updateCnt = 0;

                _logger.Info("承認対象の承認処理 開始");

                try
                {
                    // トランザクション開始
                    dao.BeginTransaction();

                    // 承認処理
                    foreach (var approvalTarget in approvalTargetList)
                    {
                        _logger.Info($"承認対象データ：CONTROL_NO[{approvalTarget.CONTROL_NO}]、STATUS[{approvalTarget.STATUS}]、USER_NAME[{_userName}]");

                        if (approvalTarget.STATUS == "2")
                        {
                            dao.Update_T_ESCALATION(approvalTarget.CONTROL_NO, "3", _userName);
                        }
                        else
                        {
                            dao.Update_T_ESCALATION(approvalTarget.CONTROL_NO, "4", _userName);
                        }

                        updateCnt++;
                    }

                    // コミット
                    dao.Commit();
                }
                catch (Exception ex)
                {
                    // ロールバック
                    dao.Rollback();                    
                    _logger.Fatal("エスカレテーブル更新処理でエラーが発生しました。");
                    _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                    new clsMessageBox().MessageBoxOKOnly("エスカレテーブル更新処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    _logger.Info("承認対象の承認処理 終了");
                }

                new clsMessageBox().MessageBoxOKOnly($"{updateCnt.ToString("#,0")}件、承認しました。", "エスカレ回答承認", MessageBoxIcon.Information);
                _logger.Info("エスカレ回答承認件数 [" + approvalTargetList.Count + "]");
                setApprovalCntDisplay();
                return;
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 戻るボタン押下
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _logger.Debug("エスカレ回答承認：戻るボタン押下");
            _logger.Info("私物返却管理DB：エスカレ回答承認 終了");
            this.Close();
        }
        #endregion

        #endregion

        #region メソッド

        #region 画面上の承認対象件数設定
        private void setApprovalCntDisplay()
        {
            _logger.Info("承認対象件数取得処理：開始");

            DataTable dtApproved = null;

            int contractCnt = 0;
            int msRTNCnt = 0;
            int msRTNOverCnt = 0;

            try
            {
                // エスカレテーブルより未承認のデータ取得
                dtNonApproved = dao.Select_NonApproved_T_ESCALATION(now);
                _logger.Info("エスカレテーブル未承認データ取得数 [" + dtNonApproved.Rows.Count + "]");

                // エスカレテーブルより承認済みの件数取得
                dtApproved = dao.Select_ApprovedCnt_T_ESCALATION();
                //approvalCnt = int.Parse(dtApproved.Rows[0]["APPROVED_CNT"].ToString());
                _logger.Info("エスカレテーブル承認済件数 [" + dtApproved.Rows.Count + "]");

                if (dtNonApproved.Rows.Count <= 0)
                {
                    _logger.Info("エスカレテーブルに該当未承認データが存在しません。");
                }
                else
                {
                    // 契約者返却未承認件数取得
                    contractCnt = dtNonApproved.AsEnumerable()
                                         .Where(row => (string)row["STATUS"] == "2").Where(row => (string)row["ESCALATION_RESPONSE"] == "1").Count();

                    // MS返却未承認件数取得
                    msRTNCnt = dtNonApproved.AsEnumerable()
                                         .Where(row => (string)row["STATUS"] == "2").Where(row => (string)row["ESCALATION_RESPONSE"] == "2").Count();

                    // MS返却(超過)未承認件数取得
                    msRTNOverCnt = dtNonApproved.AsEnumerable()
                                         .Where(row => (DateTime)row["STORAGE_PERIOD"] <= now).Where(row => new string[] { "0", "1" }.Contains((string)row["STATUS"])).Count();                                        
                }
                // 画面上の項目に取得した件数セット
                lblContractRTNCnt.Text = contractCnt.ToString("#,0");
                lblMSRTNCnt.Text = msRTNCnt.ToString("#,0");
                lblMSRTNOverCnt.Text = msRTNOverCnt.ToString("#,0");
                lblConfirmedCnt.Text = dtApproved.Rows.Count.ToString("#,0");

                // 未承認一覧GridViewバインド
                dataGridView_Approval_List_Binding();
            }
            catch(Exception ex)
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

        #region 未承認一覧GridViewバインド
        private void dataGridView_Approval_List_Binding()
        {
            int approvalListCnt = 0;

            dtos.Clear();
            dataGridView_Approval_List.DataSource = null;

            try
            {
                // エスカレ回答テーブルから入力した管理番号存在チェック
                dtEscalationResponse = dao.Select_T_ESCALATION_RESPONSE();
                _logger.Info("エスカレ回答テーブル取得数 [" + dtEscalationResponse.Rows.Count + "]");

                if (dtEscalationResponse.Rows.Count <= 0)
                {
                    _logger.Info("エスカレ回答テーブルに該当データが存在しません。");
                }                
            }
            catch (Exception ex)
            {
                _logger.Fatal("テーブルから対象データ取得でエラーが発生しました。");
                _logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                new clsMessageBox().MessageBoxOKOnly("テーブルから対象データ取得でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "エラー", MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < dtNonApproved.Rows.Count; i++)
            {
                approvalListCnt++;

                // エスカレテーブルに登録したデータを未承認一覧にバインド
                EscalationEntity dto = new EscalationEntity();                
                dto.NO = approvalListCnt;
                // 登録日の形式「yyyyMMdd」を「yyyy/MM/dd」に変換して「登録日」項目にセット
                DateTime dateTime = DateTime.ParseExact(dtNonApproved.Rows[i]["REGIST_DATE"].ToString(), "yyyyMMdd", null);
                dto.REGIST_DATE = dateTime.ToString("yyyy/MM/dd");
                dto.PRODUCT_TYPE = dtNonApproved.Rows[i]["PRODUCT_TYPE"].ToString();
                dto.CONTROL_NO = dtNonApproved.Rows[i]["CONTROL_NO"].ToString();
                dto.CONTRACT_NO = dtNonApproved.Rows[i]["CONTRACT_NO"].ToString();

                // 回答_TEMPの「ESCALATION_RESPONSE」値に対するエスカレ回答テーブルの「RESPONSE_TEXT」取得して「エスカレ回答」項目にセット
                string displayName = dtEscalationResponse.AsEnumerable()
                                     .Where(row => (string)row["RESPONSE_CODE"] == dtNonApproved.Rows[i]["ESCALATION_RESPONSE"].ToString())
                                     .Select(row => (string)row["RESPONSE_TEXT"])
                                     .FirstOrDefault();
                dto.ESCALATION_RESPONSE = displayName;
                dto.STATUS = dtNonApproved.Rows[i]["STATUS"].ToString();

                dtos.Add(dto);
            }
            //担当者のリストをDataGridViewにデータバインドする
            dataGridView_Approval_List.DataSource = dtos;

            //データグリッドのタイトル設定
            dataGridView_Approval_List.Columns[0].HeaderText = "承認\r\nチェック";
            dataGridView_Approval_List.Columns[1].HeaderText = "NO";
            dataGridView_Approval_List.Columns[2].HeaderText = "登録日";
            dataGridView_Approval_List.Columns[3].HeaderText = "種別";
            dataGridView_Approval_List.Columns[4].HeaderText = "管理番号";
            dataGridView_Approval_List.Columns[5].HeaderText = "証券番号";
            dataGridView_Approval_List.Columns[6].HeaderText = "エスカレ回答";
            dataGridView_Approval_List.Columns[7].HeaderText = "ステータス";

            //データグリッドのヘッダーの折り返して表示
            dataGridView_Approval_List.Columns[0].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            
            //更新禁止            
            dataGridView_Approval_List.Columns[1].ReadOnly = true;
            dataGridView_Approval_List.Columns[2].ReadOnly = true;
            dataGridView_Approval_List.Columns[3].ReadOnly = true;
            dataGridView_Approval_List.Columns[4].ReadOnly = true;
            dataGridView_Approval_List.Columns[5].ReadOnly = true;
            dataGridView_Approval_List.Columns[6].ReadOnly = true;
            dataGridView_Approval_List.Columns[7].ReadOnly = true;

            //更新可能
            dataGridView_Approval_List.Columns[0].ReadOnly = false;

            //ステータス非表示
            dataGridView_Approval_List.Columns[7].Visible = false;

            //初期表示の選択されているセルをなくす
            dataGridView_Approval_List.CurrentCell = null;
            
            //ヘッダテキストの文字列の折り返しを抑止
            dataGridView_Approval_List.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            //ヘッダテキストの文字配置はセル内センター
            dataGridView_Approval_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //各列のソートを抑止(抑止しないとヘッダテキストがセンターにならない)
            foreach (DataGridViewColumn c in dataGridView_Approval_List.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //列の自動設定を抑止
            dataGridView_Approval_List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //各列の幅を設定
            dataGridView_Approval_List.Columns[0].Width = 70;
            dataGridView_Approval_List.Columns[1].Width = 40;
            dataGridView_Approval_List.Columns[2].Width = 90;
            dataGridView_Approval_List.Columns[3].Width = 92;
            dataGridView_Approval_List.Columns[4].Width = 160;
            dataGridView_Approval_List.Columns[5].Width = 175;
            dataGridView_Approval_List.Columns[6].Width = 100;
            dataGridView_Approval_List.Columns[7].Width = 100;

            //文字サイスを設定
            dataGridView_Approval_List.Font = new Font("メイリオ", 9F);

            //列のセルのテキストの配置を上下左右とも中央にする
            dataGridView_Approval_List.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Approval_List.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 選択モードを行単位での選択のみにする
            dataGridView_Approval_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //DataGridViewでセル、行、列が複数選択できないようにする
            dataGridView_Approval_List.MultiSelect = false;            

        }
        #endregion

        #region 一括チェック（ON/OFF）ボタン押下
        private void btnCheckAllClick(object sender, EventArgs e)
        {
            bool allChecked = true;

            // 未承認一覧のチェックボックスがチェックされているか判定
            foreach (DataGridViewRow row in dataGridView_Approval_List.Rows)
            {
                if (!(bool)row.Cells[0].Value)
                {
                    allChecked = false;
                    break;
                }
            }

            // 未承認一覧の全チェックボックスの一括チェックON/OFF
            foreach (DataGridViewRow row in dataGridView_Approval_List.Rows)
            {
                row.Cells[0].Value = !allChecked;
            }
        }
        #endregion

        #endregion

    }
}
