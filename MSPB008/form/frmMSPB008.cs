using log4net;
using MSPB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSPB.MSPB008.form
{

    /// <summary>
    /// 仕訳コード更新画面
    /// </summary>
    class frmMSPB008 : Form
    {
        #region デザイン
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label header1;
        private Panel panelSetFile;
        private Button button1;
        private TextBox txtFile;
        private Label label2;
        private Panel panelResult;
        private TextBox textBox1;
        private Label label3;
        private Panel panelBtn;
        private Button btnUpdate;
        private Button btnCancel;
        private System.Windows.Forms.Label header0;
        

        /// <summary>
        /// デザイン
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.panelSetFile = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelSetFile.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panelBtn.SuspendLayout();
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
            this.header1.Location = new System.Drawing.Point(231, 51);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(207, 36);
            this.header1.TabIndex = 0;
            this.header1.Text = "仕分けコード更新";
            // 
            // panelSetFile
            // 
            this.panelSetFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelSetFile.Controls.Add(this.button1);
            this.panelSetFile.Controls.Add(this.txtFile);
            this.panelSetFile.Controls.Add(this.label2);
            this.panelSetFile.Location = new System.Drawing.Point(41, 113);
            this.panelSetFile.Name = "panelSetFile";
            this.panelSetFile.Size = new System.Drawing.Size(592, 153);
            this.panelSetFile.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(490, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.Color.White;
            this.txtFile.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFile.Location = new System.Drawing.Point(58, 54);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(407, 55);
            this.txtFile.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(54, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "仕分けコードを指定";
            // 
            // panelResult
            // 
            this.panelResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelResult.Controls.Add(this.textBox1);
            this.panelResult.Controls.Add(this.label3);
            this.panelResult.Location = new System.Drawing.Point(41, 272);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(592, 250);
            this.panelResult.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(58, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(407, 188);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(54, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "処理結果";
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.btnUpdate);
            this.panelBtn.Controls.Add(this.btnCancel);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(0, 528);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(670, 98);
            this.panelBtn.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(400, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(99, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 36);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // frmMSPB008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(670, 626);
            this.Controls.Add(this.panelBtn);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelSetFile);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMSPB008";
            this.Text = "MS 私物返却管理DB 仕分けコード更新";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelSetFile.ResumeLayout(false);
            this.panelSetFile.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.panelBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

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

        //config設定
        //仕分コードファイル選択用初期フォルダ
        public string SORTING_CODE_INPUT_PATH = System.Configuration.ConfigurationManager.AppSettings["MSPB008_SORTING_CODE_INPUT_PATH"];
        //仕分コードファイル名先頭
        public string SORTING_CODE_FILE_NAME_HEAD = System.Configuration.ConfigurationManager.AppSettings["MSPB008_SORTING_CODE_FILE_NAME_HEAD"];
        //仕分コードファイルヘッダ文字列
        public string SORTING_CODE_FILE_HEADER = System.Configuration.ConfigurationManager.AppSettings["MSPB008_SORTING_CODE_FILE_HEADER"];

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMSPB008(string userName)
        {
            this.UserName = userName;
            InitializeComponent();

            //参照ボタンにフォーカスを設定
            this.ActiveControl = this.button1;
            //更新ボタンを無効化
            this.btnUpdate.Enabled = false;

            //Form画面の背景色&ラベルの文字色を初期設定
            var formInit = new frmBackColorChange();
            formInit.Set_FormInit(this);
        }
        #endregion

        #region イベント

        #region 参照ボタン押下
        /// <summary>
        /// 参照ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            //ファイルダイアログの設定
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "仕分けコードファイルの選択";
            //パス初期値を設定
            string path = null;
            if (string.IsNullOrEmpty(SORTING_CODE_INPUT_PATH))
            {
                path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            else
            {
                //絶対パスに変更
                path = System.IO.Path.GetFullPath(SORTING_CODE_INPUT_PATH);
            }
            op.InitialDirectory = path;
            op.FileName = SORTING_CODE_FILE_NAME_HEAD + "*.csv";
            op.Filter = "仕分けコードファイル|*.csv";
            op.FilterIndex = 1;
            op.Multiselect = false;

            DialogResult dr = op.ShowDialog();
            //"開く"ボタン押下
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = op.FileName;
                //更新ボタンを有効に
                this.btnUpdate.Enabled = true;
                //処理結果欄クリア
                textBox1.Text = "";
            }
            //"キャンセル"ボタン押下
            else
            {
                return;
            }
        }

        #endregion

        #region キャンセルボタン押下
        /// <summary>
        /// キャンセルボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            logger.Debug("仕訳コード更新：キャンセルボタン押下");
            this.Close();
        }

        #endregion

        #region 更新ボタン押下
        /// <summary>
        /// 更新ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string out_string = null;
            string Result = null;
            string line = "";
            List<string> list = new List<string>();

            //カーソルを待機状態
            Cursor.Current = Cursors.WaitCursor;

            //仕分けコードファイルの存在確認
            if (!System.IO.File.Exists(txtFile.Text))
            {
                logger.Info("指定されたファイルが存在しません" + txtFile.Text);                
                new clsMessageBox().MessageBoxOKOnly("指定されたファイルが存在しません。" + Environment.NewLine + txtFile.Text + Environment.NewLine + "確認願います。", "強制終了", MessageBoxIcon.Exclamation);
                //カーソルを元に戻す
                Cursor.Current = Cursors.Default;
                return;
            }

            //全行読み込んでヘッダ行チェックする
            using (System.IO.StreamReader file = new System.IO.StreamReader(txtFile.Text, Encoding.GetEncoding("shift_jis")))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] fields = line.ToString().Split(',');
                    //ヘッダ行チェック
                    if (!string.IsNullOrEmpty(fields[0]) && fields[0].ToString() == SORTING_CODE_FILE_HEADER)
                    {
                        continue;
                    }
                    list.Add(line);
                }
            }

            //項目数のチェック
            for (int r = 0; r < list.Count(); r++)
            {
                string[] fields = list[r].ToString().Split(',');
                if (fields.Length != 13)
                {
                    logger.Info("データが違います。");
                    new clsMessageBox().MessageBoxOKOnly("データが違います。" + Environment.NewLine + "確認願います。", "強制終了", MessageBoxIcon.Exclamation);

                    //処理結果表示
                    out_string = "処理状況　　 : 異常" + "\r\n" + "\r\n" +
                                 "入力ファイル : " + System.IO.Path.GetFileName(txtFile.Text) + "\r\n" +
                                 "入力件数　　 : " + (list.Count -1) + "件";
                    textBox1.Text = out_string;

                    //カーソルを元に戻す
                    Cursor.Current = Cursors.Default;

                    return;
                }
            }

            //各行単位にエラーチェックを実施
            string status = "0";
            //for (int r = 0; r < list.Count(); r++)
            for (int r = 1; r < list.Count(); r++)
            {
                string[] fields = list[r].ToString().Split(',');

                //業種　必須・2バイト固定
                if (string.IsNullOrEmpty(fields[0]) || (!string.IsNullOrEmpty(fields[0]) && fields[0].Length != 2))
                {
                    status = "1";
                    break;
                }
                //郵便番号　必須・7バイト固定
                if (string.IsNullOrEmpty(fields[1]) || (!string.IsNullOrEmpty(fields[1]) && fields[1].Length != 7))
                {
                    status = "1";
                    break;
                }
                //店コ－ド　必須・6バイト固定
                if (string.IsNullOrEmpty(fields[2]) || (!string.IsNullOrEmpty(fields[2]) && fields[2].Length != 6))
                {
                    status = "1";
                    break;
                }
                //☆仕分番号☆　必須・6バイト固定
                if (string.IsNullOrEmpty(fields[3]) || (!string.IsNullOrEmpty(fields[3]) && fields[3].Length != 6))
                {
                    status = "1";
                    break;
                }
                //都道府県コ－ド　必須
                if (string.IsNullOrEmpty(fields[4]) || (!string.IsNullOrEmpty(fields[4]) && fields[4].Length > 2))
                {
                    status = "1";
                    break;
                }
                //市区町村コ－ド　必須
                if (string.IsNullOrEmpty(fields[5]) || (!string.IsNullOrEmpty(fields[5]) && fields[5].Length > 3))
                {
                    status = "1";
                    break;
                }
                //補助住所コ－ド　項目長オーバー
                if (!string.IsNullOrEmpty(fields[6]) && fields[6].Length > 3)
                {
                    status = "1";
                    break;
                }
                //丁目コ－ド　項目長オーバー
                if (!string.IsNullOrEmpty(fields[7]) && fields[7].Length > 3)
                {
                    status = "1";
                    break;
                }

                //地区割増区分　項目長オーバー
                if (!string.IsNullOrEmpty(fields[8]) && fields[8].Length > 1)
                {
                    status = "1";
                    break;
                }
                //冬期割増区分　項目長オーバー
                if (!string.IsNullOrEmpty(fields[9]) && fields[9].Length > 1)
                {
                    status = "1";
                    break;
                }
                //離島区分　項目長オーバー
                if (!string.IsNullOrEmpty(fields[10]) && fields[10].Length > 1)
                {
                    status = "1";
                    break;
                }
                //配達距離km　項目長オーバー
                if (!string.IsNullOrEmpty(fields[11]) && fields[11].Length > 3)
                {
                    status = "1";
                    break;
                }
                //配達不可区分　項目長オーバー
                if (!string.IsNullOrEmpty(fields[12]) && fields[12].Length > 1)
                {
                    status = "1";
                    break;
                }
            }
            if (status == "1")
            {
                logger.Info("データが違います。");
                new clsMessageBox().MessageBoxOKOnly("データが違います。" + Environment.NewLine + "確認願います。", "強制終了", MessageBoxIcon.Exclamation);

                //処理結果表示
                out_string = "処理状況　　 : 異常" + "\r\n" + "\r\n" +
                             "入力ファイル : " + System.IO.Path.GetFileName(txtFile.Text) + "\r\n" +
                             "入力件数　　 : " + (list.Count - 1) + "件";
                textBox1.Text = out_string;

                //カーソルを元に戻す
                Cursor.Current = Cursors.Default;

                return;
            }

            //仕分けテーブルデータ更新
            using (var dao = new dao.daoMSPB008("DBConnection", Environment.UserName))
            {
                try
                {
                    //出荷依頼テーブルの更新

                    //トランザクション開始
                    dao.BeginTransaction();

                    //仕分けテーブルデータ削除
                    dao.delete_M_SORTING_CODE();

                    //仕分けテーブルデータ更新
                    for (int r = 1; r < list.Count(); r++)
                    {
                        dao.insert_M_SORTING_CODE(list[r].ToString(), UserName);
                    }

                    //処理履歴テーブルへの追加
                    int max_SEQ_NO_T_PROCESS_HISTORY = 0;
                    max_SEQ_NO_T_PROCESS_HISTORY = dao.select_MAX_SEQ_NO_From_T_PROCESS_HISTORY();
                    logger.Info("処理履歴テーブルより最大SEQ_NO:" + max_SEQ_NO_T_PROCESS_HISTORY);
                    dao.insert_T_PROCESS_HISTORY(max_SEQ_NO_T_PROCESS_HISTORY + 1, "仕分けコード更新", System.IO.Path.GetFileName(txtFile.Text), (list.Count - 1), (list.Count - 1), UserName);

                    //コミット
                    dao.Commit();

                    Result = "OK";
                }
                catch (Exception ex)
                {
                    //ロールバック
                    dao.Rollback();

                    logger.Fatal("DB処理でエラーが発生しました。");
                    logger.Fatal("エラー内容：" + ex.Message + Environment.NewLine + ex.StackTrace);
                    DialogResult result = new clsMessageBox().MessageBoxOKOnly("DB処理でエラーが発生しました。" + Environment.NewLine + "開発部門に問い合わせ願います。", "警告", MessageBoxIcon.Warning);

                    //処理結果表示
                    out_string = "処理状況　　 : 異常" + "\r\n" + "\r\n" +
                                 "入力ファイル : " + System.IO.Path.GetFileName(txtFile.Text) + "\r\n" +
                                 "入力件数　　 : " + (list.Count-1) + "件"; //ヘッダー抜き
                    textBox1.Text = out_string;

                    Result = "NG";

                    //カーソルを元に戻す
                    Cursor.Current = Cursors.Default;

                    return;
                }
                finally
                {
                    logger.Info("仕分けテーブルデータ更新 終了");
                }
            }

            //処理結果表示
            if (Result == "OK")
            {
                out_string = "処理状況　　 : 正常" + "\r\n" + "\r\n" +
                             "入力ファイル : " + System.IO.Path.GetFileName(txtFile.Text) + "\r\n" +
                             "入力件数　　 : " + (list.Count - 1) + "件"; //ヘッダー抜き
                textBox1.Text = out_string;
            }

            //カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }


        #endregion

        #endregion

    }
}
