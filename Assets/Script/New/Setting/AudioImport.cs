using System.Collections;
using UnityEngine;
using System.Windows.Forms; //OpenFileDialog用に使う
using UniRx;
using System;

namespace Ken.Setting{
    public class AudioImport : MonoBehaviour
    {
        public AudioImporter importer;
        public AudioSource audioSource;
        public IReadOnlyReactiveProperty<string> ClipName => _clipName;
        private readonly ReactiveProperty<string> _clipName = new ReactiveProperty<string>("楽曲名");

        public IObservable<Unit> OnSelectMusic => _selectMusic;
        private Subject<Unit> _selectMusic = new Subject<Unit>();

        string path="";

        public void MusicSelect()
        {

            OpenFileDialog open_file_dialog = new OpenFileDialog();

            //InputFieldの初期値を代入しておく(こうするとダイアログがその場所から開く)
            open_file_dialog.FileName = path;

            //mp3ファイルを開くことを指定する
            open_file_dialog.Filter = "Mp3ファイル|*.mp3";

            //ファイルが実在しない場合は警告を出す(true)、警告を出さない(false)
            open_file_dialog.CheckFileExists = false;

            //ダイアログを開く
            open_file_dialog.ShowDialog();

            path = open_file_dialog.FileName;

            //クリップに付け替え
            Destroy(audioSource.clip);

            StartCoroutine(Import(path));

        }

        IEnumerator Import(string path)
        {
            importer.Import(path);

            while (!importer.isInitialized && !importer.isError)
                yield return null;

            if (importer.isError)
                Debug.LogError(importer.error);

            audioSource.clip = importer.audioClip;

            //完了通知
            _selectMusic.OnNext(Unit.Default);
            //クリップ名取得
            _clipName.Value = importer.audioClip.ToString();
        }
    }
}
