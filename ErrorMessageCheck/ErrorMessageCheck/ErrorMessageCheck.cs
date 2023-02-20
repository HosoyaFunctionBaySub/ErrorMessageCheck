using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ErrorMessageCheck
{
    public partial class ErrorMessageCheck : Form
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ErrorMessageCheck());
        }

        public ErrorMessageCheck()
        {
            InitializeComponent();
        }

        private void button_MSG_Click(object sender, EventArgs e)
        {
            this.openFileDialog_MSG.DefaultExt = ".msg";
            this.openFileDialog_MSG.Filter = "Message File(*.msg)|*.msg|All Files(*.*)|*.*";
            this.openFileDialog_MSG.FilterIndex = 1;
            if (openFileDialog_MSG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog_MSG.FileName);
                    string filepath = openFileDialog_MSG.FileName;
                    richTextBox_MSG.Text = System.IO.Path.GetFullPath(filepath);
                    sr.Close();
            }
            richTextBox_Version.Clear();
            richTextBox_err.Clear();
            richTextBox_workaround.Clear();
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            try
            {
                int line_num = GetMessageLine(this.richTextBox_MSG.Text);
                string[] line = new string[line_num];
                char[] separator = new char[] { ',' };
                System.IO.StreamReader msg_file = new StreamReader(this.richTextBox_MSG.Text);
                for (int i = 0; i < line_num; i++)
                {
                    line[i] = msg_file.ReadLine();
                    if (0 <= line[i].IndexOf("Analysis message file."))
                    {
                        richTextBox_Version.Text = line[i];
                    }
                    string err_message = GetMessage(line[i]);
                    string[] line_part = err_message.Split(separator);
                    if (line_part[0] == "1")
                    {
                        richTextBox_err.Text = line_part[1];
                        richTextBox_workaround.Text = line_part[2];
                        break;
                    }
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("メッセージファイルを指定してください。", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
            }
        }

        private int GetMessageLine(string filename)
        {
            int line_num = 0;
            System.IO.StreamReader msg_file = new StreamReader(filename);
            while (msg_file.ReadLine() != null)
            {
                line_num++;
            }
            return line_num;
        }

        private string GetMessage(string line)
        {
            string err_message = null;
            string[,] message = new string[50, 2];

            //エラーメッセージと対策のデータベース
            //追加方法：以下の書式でデータを末尾に追加
            //*はID。末尾番号の連番を入力する。
            //message[*, 0] = "エラーメッセージの一部(他のエラーメッセージと重複しない文字列)";
            //message[*, 1] = "エラーに対する対策";

            message[0, 0] = "current step size is too small";
            message[0, 1] = "突然、巨大なフォースが発生する等により時間刻みが0に限りなく近づいたことが原因です。" + "\r\n" +
                "以下の対策を実施してください。" + "\r\n" + "\r\n" +
                "1. 解析実行時にエラーが表示される場合は初期の時間刻みを十分に小さな値にします。" + "\r\n" +
                "2. 解析中にエラーが表示される場合は最大の時間刻みおよび許容誤差を小さな値します。" + "\r\n" +
                "3. 突然大きなフォースが発生するのを防止します。（接触剛性をできるだけ下げる、バネ係数を下げる等）" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「CURRENT STEPSIZE IS TOO SMALLというエラーメッセージが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/200/";

            message[1, 0] = "JACOBIAN MATRIX IS SINGULAR";
            message[1, 1] = "主にモデル内に質量や慣性モーメントが”0″のボディが存在する場合に発生します。" + "\r\n" +
                "(ただし、他のボディに固定されている場合は発生しません。)" + "\r\n" +
                "該当ボディのプロパティを開き手動で質量を入力するか、必要ないボディであれば削除してください。" + "\r\n" + "\r\n" +
                "この他に、以下の場合にも発生することがあるので、ご確認ください。" + "\r\n" +
                "1. ジョイントやフォースを定義した後に、ボディを移動してベースマーカーとアクションマーカーの位置や姿勢がずれていないか。" + "\r\n" +
                "2. フォースや接触で瞬間的に過大な荷重やトルクが発生していないか。" + "\r\n" +
                "3. 「現在の姿勢で保存」した場合、タイムオフセットの設定が適切になっているか。" + "\r\n" +
                "4. モデルが過剰拘束になっていないか。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「JACOBIAN MATRIX IS SINGULAR というエラーメッセージが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/192/";

            message[2, 0] = "CONVERGENCY IS FAILED IN ACCELERATION ANALISYS";
            message[2, 1] = "モデルの初期状態に問題がある場合に発生します。以下に該当する項目がないかご確認ください。" + "\r\n" + "\r\n" +
                "1. F-Flexボディの節点の位置にジョイントやフォースが定義されているか。" +
                "2. 初期状態で一致していなければならないジョイントのマーカーがずれていないか。" + "\r\n" +
                "3. 定義したモーションとモデルの初期状態が合致するか。" + "\r\n" +
                "4. モーションに不適切な数式が入っていないか。モーションタイプに誤りがないか。" + "\r\n" +
                "5. 解析の再スタート機能を使用している場合、 タイムオフセットに誤りがないか。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「CONVERGENCY IS FAILED IN ACCELERATION ANALISYSというエラーメッセージが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/fflex/error-fflex/296/";

            message[3, 0] = "FLOATING MARKER CAN NOT BE USED IN DISPLACEMENT EXPRESSION";
            message[3, 1] = "距離関数や速度関数の引数に三方向フォースや六方向フォースなどのベースマーカー(フローティングマーカー)を使用した場合に発生します。 " + "\r\n" +
                "該当するマーカーと同じ位置に新しいマーカーを作成し、作成したマーカーを数式内の引数リストに指定してください。 " + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「FLOATING MARKER CAN NOT BE USED IN DISPLACEMENT EXPRESSIONというエラーが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/195/";

            message[4, 0] = "THE POSITIONS OF TWO MARKERS OF AN AXIAL FORCE ARE SAME";
            message[4, 1] = "二点間フォースのベースマーカーとアクションマーカーを同じポイントに定義した場合に発生します。" + "\r\n" +
                "二点間フォースはベースマーカーとアクションマーカーを結ぶ方向にフォースを発生させるので、ベースマーカーとアクションマーカーを同じポイントに定義するとフォースの方向が決まりません。ベースマーカーとアクションマーカーのポイントは異なる位置に定義してください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「THE POSITIONS OF TWO MARKERS OF AN AXIAL FORCE ARE SAMEというエラーが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/187/";

            message[5, 0] = "THE DISTANCE BETWEEN TWO MARKERS OF A TSD IS ZERO";
            message[5, 1] = "並進バネのベースマーカーとアクションマーカーを同じポイントに定義した場合に発生します。" + "\r\n" +
                "ベースマーカーとアクションマーカーは異なるポイントに定義してください。" + "\r\n" +
                "ベースマーカーとアクションマーカーを同じポイントに定義したい場合にはブッシングを使用してください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "「THE DISTANCE BETWEEN TWO MARKERS OF A TSD IS ZEROというエラーメッセージが出る。」" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/188/";

            message[6, 0] = "DISPLACEMENT EXPRESSION IS NOT AVAILABLE IN MOTION";
            message[6, 1] = "モーションの数式内では位置関数を直接使用することができません。" + "\r\n" +
                "このような場合は、以下に紹介する2つの方法のいずれかをご使用ください。" + "\r\n" + "\r\n" +
                "◆方法１：フォース要素とフィードバック制御式を使用" + "\r\n" +
                "並進運動なら『二点間フォース』や『三方向フォース』、回転運動なら『軸トルク』を定義し、フォース要素にフィードバック制御式を定義します。" + "\r\n" +
                "※フィードバック制御式については演習問題12・13をご参照ください。" + "\r\n" +
                "《位置のフィードバック制御式》" + "\r\n" +
                "ゲイン*(目標位置-対象位置)" + "\r\n" +
                "※ゲインはモデルごとに調整が必要です。" + "\r\n" + "\r\n" +
                "◆方法２：代数方程式を使用" + "\r\n" +
                "測定したい位置関数の数式を代数方程式として登録し、VARVAL関数で引用します。" + "\r\n" +
                "○操作手順" + "\r\n" +
                "(1)測定したい位置関数の数式を作成します。" + "\r\n" +
                "(2)この数式を代数方程式に登録します。" + "\r\n" +
                "(3)モーションに入力する数式を作成します。" + "\r\n" +
                "ここで(1)で作成した数式をVARVAL関数を用いて入力します。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "あるボディの運動を強制運動(モーション)として他のボディに与えようとすると、『MARKERS CAN NOT BE USED IN MOTION』というエラーが発生して解析実行ができない。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/modeling/modeling-modeling/56/";

            message[7, 0] = "A LENGTH OF FILEPATH IS SO LONG";
            message[7, 1] = "モデルファイル名とパスが長すぎることが原因でエラーが発生しています。" + "\r\n" +
                "RecurDynで扱うことのできるモデルファイル名＋パスの長さの合計は半角英数で255文字以下です。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "解析実行時に「ERROR : A LENGTH OF FILEPATH IS SO LONG」というエラーが表示され解析を開始できません。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/189/";

            message[8, 0] = "Can't find Force Element";
            message[8, 1] = "フォースの発生しないマーカーをフォースのリクエストで使用している場合に発生します。" + "\r\n" +
                "フォースタイプのリクエストを使用する際は、フォースまたはジョイントのマーカーを設定してください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "標準リクエストでフォースを指定した際、「*ERROR : Can’t find Force Element」というエラーが出ます。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/197/";

            message[9, 0] = "SOLVER CAN NOT FIND DLL FILE FOR USER SUB";
            message[9, 1] = "ユーザーサブルーチンのDLLファイルに問題がある場合に発生します。以下に該当する項目がないかご確認ください。" + "\r\n" + "\r\n" +
                "1. モデルで使用しているユーザーサブルーチンのDLLファイルが所定のフォルダーに保存されているか。" + "\r\n" +
                "2. DLLファイルをデバックモードでコンパイルしている場合はリリースモードでコンパイルしてください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "他マシンで使用可能なDLLファイルを使用したら、解析実行時に『SOLVER CAN NOT FIND DLL FILE FOR USER SUB.』というエラーが発生する。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/modeling/modeling-modeling/54/";

            message[10, 0] = "The selected markers must belong to a force entity.";
            message[10, 1] = "無効化したフォースのマーカーを数式の汎用フォース・トルク関数で使用している場合に発生します。" + "\r\n" +
                "汎用フォース・トルク関数(FM,FX,FY,FZ,TM,TX,TY,TZ)を使用した数式をご確認ください。";

            message[11, 0] = "P2P(SOLID) – CONTACT > PatchToPatchConnectivity";
            message[11, 1] = "接触計算用に生成されたパッチに問題がある場合に発生します。" + "\r\n" +
                "本来、1本のラインには1枚、または2枚の三角パッチが接しますが、3個以上の三角パッチが1本のラインに接している場合に本エラーが発生します。" + "\r\n" +
                "このエラーが出ていてもソルバーの内部処理により解析はできます。本エラーを解消する場合は問題となっている形状を発見し、形状を修正することが必要となります。なお、パッチサイズの変更で回避できる場合もあります。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "解析中にP2P(SOLID) – CONTACT > PatchToPatchConnectivityというメッセージが出る。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/185/";

            message[12, 0] = "Acceleration analysis failed to converge in Static analysis";
            message[12, 1] = "静的つり合い解析が収束しない場合に表示されます。以下のソルバーパラメーターを調整してください。" + "\r\n" + "\r\n" +
                "1. ソルバーの種類の変更" + "\r\n" +
                "　 N-R、Robust N-R、Augmented N-Rの中から選択します。弾性体を含むモデルの場合は、Augmented N-Rの使用を推奨します。" + "\r\n" +
                "2. 繰り返し数の調整" + "\r\n" +
                "　 メッセージウィンドウに表示されるDELTANORMが減少傾向なら増やします。減少傾向で無い場合、繰り返し数の調整に効果はありません。" + "\r\n" + "\r\n" +
                "モデルの自由度が大きい場合や弾性体を含むモデルにおいては、静的つりあい解析でつりあい位置を見つけることが難しくなりがちです。" + "\r\n" +
                "特に接触を含む場合、ボディ同士が大きく干渉するような状態では収束しにくくなります。このような場合はダイナミック解析でつりあい位置を求め、つりあい状態で「現在の姿勢で保存」する方法も有効です。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "静的つりあい解析が収束しません" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/solver/10684/";

            message[13, 0] = "CONVERGENCY IS FAILED IN THE STATIC ANALYSIS";
            message[13, 1] = "静的つり合い解析が収束しない場合に表示されます。以下のソルバーパラメーターを調整してください。" + "\r\n" + "\r\n" +
                "1. ソルバーの種類の変更" + "\r\n" +
                "   N-R、Robust N-R、Augmented N-Rの中から選択します。弾性体を含むモデルの場合はAugmented N-Rの使用を推奨します。" + "\r\n" +
                "2. 繰り返し数の調整" + "\r\n" +
                "   メッセージウィンドウに表示されるDELTANORMが減少傾向なら増やします。減少傾向で無い場合、繰り返し数の調整に効果はありません。" + "\r\n" + "\r\n" +
                "モデルの自由度が大きい場合や弾性体を含むモデルにおいては、静的つりあい解析でつりあい位置を見つけることが難しくなりがちです。" + "\r\n" +
                "特に接触を含む場合、ボディ同士が大きく干渉するような状態では収束しにくくなります。このような場合はダイナミック解析でつりあい位置を求め、つりあい状態で「現在の姿勢で保存」する方法も有効です。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "静的つりあい解析が収束しません" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/solver/10684/";

            message[14, 0] = "Memory could not be allocated.";
            message[14, 1] = "モデル規模が大きく、計算に必要なメモリが確保できません。" + "\r\n" +
                "ボディや接触の数を減らしてモデルを小さくするか、F-Flexボディを含む場合は節点数を減らしてください。";

            message[15, 0] = "Unable to compute the eigenvector.";
            message[15, 1] = "モデルの自由度が0なので、システムの応答を計算できません。" + "\r\n" +
                "ジョイントの設定を確認してください。" + "\r\n" +
                "なお、モーションの拘束条件の一つとなります。";

            message[16, 0] = "The simulation command must be defined.";
            message[16, 1] = "シナリオファイル(*.rss)およびシナリオコマンドに解析タイプ(SIM/)と積分器(INT/)が記載されていません。" + "\r\n" +
                "解析タイプと積分器を追加してください。";

            message[17, 0] = "The integrator command is not valid.";
            message[17, 1] = "シナリオファイル(*.rss)およびシナリオコマンドの積分器(INT/)が解析タイプに合っていない、または記載されていません。" + "\r\n" +
                "積分器を修正または追加してください。";

            message[18, 0] = "The requested number of cores is not valid";
            message[18, 1] = "解析ダイアログで設定したコア数分のSMPライセンスを取得できません。" + "\r\n" +
                "コア数を減らして、解析を実行してください。";

            message[19, 0] = "Linear solver factorization failed.";
            message[19, 1] = "モデルのパラメーターや構成に誤りがある、メモリ不足、ソルバーの不具合などが原因です。" + "\r\n" +
                "これら以外にも様々な要因が考えられます。モデル内のいくつかのエンティティを無効化し、エラーが解消されるかお試しください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "LU factorization in the sparse linear solver failed.というエラーメッセージが出る" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/fflex/error-fflex/48591/";

            message[20, 0] = "ENDTIME IS LESS THAN PAST TIME";
            message[20, 1] = "解析時間を区切ったシナリオ解析を実行した際、前の解析終了時間よりも短い解析終了時間を設定した場合に発生します。" + "\r\n" +
                "シナリオコマンドの解析時間を修正してください。";

            message[21, 0] = "C000115";
            message[21, 1] = "各FDR要素のスレーブ節点に同じ節点が選択され、重複している可能性があります。" + "\r\n" +
                "スレーブ節点が重複しているFDR要素があれば、スレーブ節点を修正してください。";

            message[22, 0] = "The slave nodes of an RBE3(FDR - InterE) element must not be collinear.";
            message[22, 1] = "FDR要素のInterpEタイプを使用する際はスレーブ節点には4点以上の節点を指定してください。";

            message[23, 0] = "LU factorization in the sparse linear solver failed.";
            message[23, 1] = "F-Flexボディを含むモデルでこのエラーが発生する場合、以下の原因が考えられます。" + "\r\n" + "\r\n" +
                "1. 境界条件を設定した節点にジョイントが重複して定義されている。" + "\r\n" +
                "2. FDR要素の従属節点に境界条件が設定されている。" + "\r\n" +
                "3. 計算に必要なマシンのメモリーが足りない。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "LU factorization in the sparse linear solver failed.というエラーメッセージが出る" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/fflex/error-fflex/48591/";

            message[24, 0] = "There is invalid data. this error occurs when a large force is generated in an entity.";
            message[24, 1] = "超弾性材料を使用したF-Flexボディの変形量が非常に大きい時に発生する場合があります。" + "\r\n" +
                "要素のひずみ量に対して適切な材料パラメーターが設定されているか確認してください。";

            message[25, 0] = "unknown token";
            message[25, 1] = "R-FLEXのrfiファイルの保存場所へのパスに読み込めない文字が含まれている場合に発生します。" + "\r\n" +
                "RFIファイルを保存したフォルダーおよびRFIファイル名に以下の文字が含まれていないか確認してください。" + "\r\n" +
                "読み込めない文字の例：半角スペース, ! , ( , ) , =" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "unknown tokenというメッセージが出て、解析が流れない" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/rflex/error_rflex/317/";

            message[26, 0] = "This icf file dose not match the current model.";
            message[26, 1] = "ICFファイルのモデルデータと現在のモデルデータが一致しません。" + "\r\n" +
                "ICFファイル作成時のモデルから変更点があれば、元に戻してください。";

            message[27, 0] = "INCREASE MAXIMUM NO. SHEET SEGMENT";
            message[27, 1] = "MTT2Dでは計算時間を軽減するために、モデル領域を分割し、タイルごとに接触判定を行います。" + "\r\n" +
                "そのタイル内で扱えるシートセグメントの数はあらかじめ決められており、計算中に1タイル内に存在するシートセグメントの数が設定された数を超える可能性があります。" + "\r\n" +
                "以下の手順で解消することができます。" + "\r\n" + "\r\n" +
                "1. データベースウィンドウの「MTT2Dアセンブリ」のプロパティを開きます。" + "\r\n" +
                "2. 右下の「パラメーター」ボタンをクリックします。" + "\r\n" +
                "3. 「1タイルあたり最大シートセグメント」にチェックを入れて数値を大きくします。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "INCREASE MAXIMUM NO. SHEET SEGMENT というエラーメッセージが出る。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/mtt2d_mtt3d_r2r2d/mtt2d/351/";

            message[28, 0] = "INCREASE MAXIMUM NO. SHEET ELEMENT";
            message[28, 1] = "MTT3Dでは計算時間を軽減するために、モデル領域を分割し、タイルごとに接触判定を行います。" + "\r\n" +
                "そのタイル内で扱える要素の数はあらかじめ決められており、計算中に1タイル内に存在する要素の数が設定された数を超える可能性があります。" + "\r\n" +
                "以下の手順で解消することができます。" + "\r\n" + "\r\n" +
                "1. データベースウィンドウの「MTT3Dアセンブリ」のプロパティを開きます。" + "\r\n" +
                "2. 右下の「パラメーター」ボタンをクリックします" + "\r\n" +
                "3. 「1タイルあたり最大シートセグメント」にチェックを入れて数値を大きくします。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "INCREASE MAXIMUM NO. SHEET ELEMENT というエラーメッセージが出る。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/mtt2d_mtt3d_r2r2d/mtt3d/362/";

            message[29, 0] = "Cannot Import ICF File";
            message[29, 1] = "ボディやジョイントを追加/削除/編集したモデルに初期状態ファイル(*.icf)をインポートしている場合に発生します。" + "\r\n" +
                "条件の異なるモデルに初期状態ファイルはインポートできないので、モデルを元に戻すか、初期状態ファイルを再作成してください。";

            message[30, 0] = "FROLLER_2D 3 ERROR:Not Declared But Used";
            message[30, 1] = "MTT2D, MTT3D使用時に、アセンブリプロパティ の接触リストにおいて、可動ローラの対になっている固定ローラのチェックが外れている場合に表示されます。修正方法は下記の通りです。" + "\r\n" + "\r\n" +
                "1. データベースウィンドウで「MTTアセンブリ」を 右クリックし「プロパティ」をクリックします。" + "\r\n" +
                "2. ダイアログが開くので、左側の「接触形状」で 固定ローラのチェックをONにします。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "ERROR:FROLLER_2D 3 ERROR:Not Declared But Used というエラーメッセージが出る" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/190/";

            message[31, 0] = "OUT OF RANGE - Z COOR";
            message[31, 1] = "計算中にリンクがスプロケットの奥行き方向に外れた場合に発生します。" + "\r\n" +
                "以下の対策を実施してください。" + "\r\n" + "\r\n" +
                "1. 最大の時間刻みや許容誤差を小さくし、解析精度を絞る。" + "\r\n" +
                "2. スプロケットのプロパティを開き「Full Search」にチェックを入れる。" + "\r\n" +
                "3. スプロケットプロパティの特性タブでStiffness Coefficient(剛性係数)を上げる。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "OUT OF RANGE – Z COOR.(SPROCKET名) というエラーが出る。" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/chain_gear_belt/chain/384/";

            message[32, 0] = "Acceleration analysis failed to converge.";
            message[32, 1] = "モデルの初期状態を計算する際の加速度解析が収束しない場合に発生します。" + "\r\n" +
                "以下の対策を実施してエラーが解消されるかご確認ください。" + "\r\n" + "\r\n" +
                "1. 剛体ボディの荷重を緩やかに立ち上げる。" + "\r\n" +
                "2. パッチセットの範囲を接触面のみに設定する。" + "\r\n" +
                "3. 初期干渉が発生しないようにする。" + "\r\n" +
                "4. R-Flexボディを含む場合、1Hz以下の次数のモードを無効にする。";

            message[33, 0] = "The value of a point must not exceed the range of the curve";
            message[33, 1] = "点カーブ拘束で拘束点がカーブの範囲を超えた場合に発生します。" + "\r\n" +
                "カーブを長くするか、拘束点のあるボディの挙動を確認してください。";

            message[34, 0] = "SIMULINK FAIL TO OPEN A SHARING MEMORY";
            message[34, 1] = "このエラーメッセージは「タイムアウト時間」 が関係しています。" + "\r\n" +
                "「タイムアウト時間」はSimulinkダイアログの中ほどに ありますので、これを長め（100倍くらい）に設定してお試しください。" + "\r\n" + "\r\n" +
                "技術サポートサイトのよくあるご質問にも記載されているので、ご参照ください。" + "\r\n" +
                "Control使用時に「SIMULINK FAIL TO OPEN A SHARING MEMORY」というエラーが出る" + "\r\n" +
                "https://support.functionbay.co.jp/app/faq/analytics/error/186/";

            message[35, 0] = "FFlex boundary conditions and FFlex constraints connectors are overlapped.";
            message[35, 1] = "特定の節点に対して、ジョイントや境界条件を重複して定義している場合に発生します。" + "\r\n" +
                "主に以下の場合に発生するので、節点のジョイントおよび境界条件を見直してください。" + "\r\n" + "\r\n" +
                "1. FDR要素のスレーブ節点に境界条件を定義している。" + "\r\n" +
                "2. 境界条件が定義されている節点にジョイントを定義している。"+"\r\n"+
                "3. 3.	FDR要素のマスター節点およびスレーブ節点の2点以上に同じ剛体ボディとのジョイントを定義している。";

            //V9R5で追加
            message[36, 0] = "Unable to get the step size";
            message[36, 1] = "Particleworksにおいて「解析領域」の設定がされていない場合に発生します。" + "\n" +
                "Particleworksで解析領域を設定し、再度連成解析を実行してください。";

            message[37, 0] = "Unable to perform Pre-analysis";
            message[37, 1] = "ジョイントのベース/アクションマーカーの位置や姿勢が一致していない場合に発生することがあります。" + "\n" +
           "RecurDynモデルにおいて、ベース/アクションマーカーにズレがないか確認ください。" + "\n" +
            "ズレがある場合はプロパティの「ベースマーカーに整列」ボタンあるいは「アクションマーカーに整列」ボタンを使用し、" + "\n" +
            "マーカーを一致させてから連成解析を実行してください。";

            //V2023で追加
            message[38, 0] = "[C0199][Prof/Expression][MOTION] The joint ID";
            message[38, 1] = "以下の2つの条件を満たす場合に発生するエラーです。" + "\n" +"\n"+
                "1.数式で特殊フォース・トルク関数MOTIONを使用している。" + "\n" +
                "2.関数MOTIONの引数となっているジョイントのモーションが無効化されている。"+"\n"+"\n"+
                "上述の条件に該当する数式を削除して、解析を実行してください。";

            message[39, 0] = "The total number of sub-boundary boxes";
            message[39, 1] = "境界ボックスを分割するボックス数が10000を超えた場合に表示され、”分割セルの数”を減らすことでエラーが解消できる可能性があります。"+"\n"+
                "”分割セルの数”については、MTT3Dマニュアルの以下をご参照ください。"+"\n"+
                "「6.1.2(1) 接触面ボタン」および「6.3.4(1) 分割セルの設定の目安」"+"\n"+
                "https://support.functionbay.co.jp/support/manual/toolkit/toolkit04.html";

            //エラーが見つからない場合
            message[40, 0] = "RecurDyn Solver has encountered a problem";
            message[40, 1] = "解析開始時または解析実行中に問題が発生しましたが、該当するエラーメッセージを発見することができませんでした。" + "\r\n" +
                "メッセージファイル(*.msg)を技術サポートにご送付ください。" + "\r\n" +
                "◇RecurDyn技術サポートのメールアドレス" + "\r\n" + "rdsup@functionbay.co.jp";

            message[41, 0] = "Analysis is accomplished successfully";
            message[41, 1] = "計算は正常に終了しました。";



            for (int j = 0; j < 40; j++)
            {
                if (0 <= line.IndexOf(message[j, 0]))
                {
                    err_message = "1," + line + "," + message[j, 1];
                    break;
                }
                else
                {
                    err_message = line;
                }
            }
            return err_message;
        }

        public System.Diagnostics.Process p = new System.Diagnostics.Process();

        private void richTextBox_workaround_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            p = System.Diagnostics.Process.Start(e.LinkText);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AB_RDGadget form1 = new AB_RDGadget();
            form1.Show();
        }
    }
}
