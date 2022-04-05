using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //Input Field用に使う
using System.Windows.Forms; //OpenFileDialog用に使う

public class Findfolder : MonoBehaviour
{
    public string handin;

    public InputField input_field_path_;

    public void OpenExistFile()
    {

        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //InputFieldの初期値を代入しておく(こうするとダイアログがその場所から開く)
        open_file_dialog.FileName = input_field_path_.text;

        //mp3ファイルを開くことを指定する
        open_file_dialog.Filter = "Mp3ファイル|*.mp3";

        //ファイルが実在しない場合は警告を出す(true)、警告を出さない(false)
        open_file_dialog.CheckFileExists = false;

        //ダイアログを開く
        open_file_dialog.ShowDialog();

        //取得したファイル名をInputFieldに代入する
        input_field_path_.text = open_file_dialog.FileName;

        handin = open_file_dialog.FileName;

    }

}

