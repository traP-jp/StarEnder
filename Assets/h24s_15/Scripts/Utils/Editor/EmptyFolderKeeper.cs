using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace h24s_15.Utils.Editor {
    //以下のコードはflanny7さんのコードを使用しています．
    //https://gist.github.com/flanny7/14e458b18a501c82413e509f1eefa139
    /// <summary>
    /// アセットを追加したタイミングで空ディレクトリに.gitkeepファイルを作成するクラス
    /// このクラスはエディタ拡張を使用しています．Editorフォルダに入れてください．
    /// </summary>
    public sealed class EmptyFolderKeeper : AssetPostprocessor {
        private static readonly string GIT_KEEP = ".gitkeep";

        /// <summary>
        /// 任意の数のアセットのインポートが完了した後に呼び出されます
        /// https://docs.unity3d.com/ja/current/ScriptReference/AssetPostprocessor.OnPostprocessAllAssets.html
        /// flanny7
        /// </summary>
        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths) {
            var isImportedAssets = 0 < importedAssets.Length;
            var isDeletedAssets = 0 < deletedAssets.Length;
            var isMovedAssets = 0 < movedFromAssetPaths.Length;

            if (isImportedAssets) {
                string[] parentPaths = null;
                CreateKeeper4EmptyDirectory(importedAssets, out parentPaths);
                DeleteKeeper4FillDirectory(parentPaths);
            }

            // アセットが削除された場合、
            // 空ディレクトリが発生する可能性があるので生成処理をかける flanny7
            if (isDeletedAssets) {
                var deletedParents = GetParentPaths(deletedAssets);
                CreateKeeper4EmptyDirectory(deletedParents);
            }

            if (isMovedAssets) {
                CreateKeeper4EmptyDirectory(movedFromAssetPaths);
                var movedParents = GetParentPaths(movedAssets);
                DeleteKeeper4FillDirectory(movedParents);
            }

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 空ディレクトリに.gitkeepを生成する flanny7
        /// </summary>
        /// <param name="_paths">検索対象となるパス</param>
        private static void CreateKeeper4EmptyDirectory(string[] _paths) {
            for (var i = 0; i < _paths.Length; ++i) {
                var path = _paths[i];

                var isDirectory = Directory.Exists(path);
                if (!isDirectory) {
                    continue;
                }

                var hasDirectory = 0 < Directory.GetDirectories(path).Length;
                var hasFile = 0 < Directory.GetFiles(path).Length;
                var isEmpty = !hasDirectory && !hasFile;

                var gitkeepPath = path + "/" + GIT_KEEP;
                var hasGitKeep = File.Exists(gitkeepPath);

                if (isEmpty && !hasGitKeep) {
                    File.Create(gitkeepPath).Close();
                    Debug.Log("<color=#5cb85c>Create</color> .gitkeep in " + path + " .");
                }
            }
        }

        /// <summary>
        /// 空ディレクトリに.gitkeepを生成する flanny7
        /// </summary>
        /// <param name="_paths">検索対象となるパス</param>
        /// <param name="_parentPaths">対象パスの親ディレクトリのパスを渡す</param>
        private static void CreateKeeper4EmptyDirectory(string[] _paths, out string[] _parentPaths) {
            var parentDirectorys = new HashSet<string>();

            for (var i = 0; i < _paths.Length; ++i) {
                var path = _paths[i];

                // 親ディレクトリの取得
                var parentPath = Directory.GetParent(path).FullName;
                if (parentPath != null && !parentDirectorys.Contains(parentPath)) {
                    parentDirectorys.Add(parentPath);
                }

                var isDirectory = Directory.Exists(path);
                if (!isDirectory) {
                    continue;
                }

                var hasDirectory = 0 < Directory.GetDirectories(path).Length;
                var hasFile = 0 < Directory.GetFiles(path).Length;
                var isEmpty = !hasDirectory && !hasFile;

                var gitkeepPath = path + "/" + GIT_KEEP;
                var hasGitKeep = File.Exists(gitkeepPath);

                if (isEmpty && !hasGitKeep) {
                    File.Create(gitkeepPath).Close();
                    Debug.Log("<color=#5cb85c>Create</color> .gitkeep in " + path + " .");
                }
            }

            _parentPaths = parentDirectorys.ToArray();
        }

        /// <summary>
        /// 対象のパスから親ディレクトリのパスを返す flanny7
        /// </summary>
        /// <param name="_paths">検索対象となるパス</param>
        /// <returns></returns>
        private static string[] GetParentPaths(string[] _paths) {
            var parents = new HashSet<string>();
            for (var i = 0; i < _paths.Length; ++i) {
                var path = _paths[i];

                var parentPath = Directory.GetParent(path).FullName;
                var isExist = Directory.Exists(parentPath);
                if (isExist && !parents.Contains(parentPath)) {
                    parents.Add(parentPath);
                }
            }

            return parents.ToArray();
        }

        /// <summary>
        /// 空でないディレクトリから.gitkeepを削除する flanny7
        /// </summary>
        /// <param name="_paths">検索対象となるパス</param>
        private static void DeleteKeeper4FillDirectory(string[] _paths) {
            for (var i = 0; i < _paths.Length; ++i) {
                var path = _paths[i];

                var gitkeepPath = path + "/" + GIT_KEEP;
                var hasGitKeep = File.Exists(gitkeepPath);

                if (!hasGitKeep) {
                    continue;
                }

                var hasDirectory = 0 < Directory.GetDirectories(path).Length;
                // .gitkeepの分は弾くため、-1個 flanny7
                var hasFile = 0 < Directory.GetFiles(path).Length - 1;
                var isEmpty = !hasDirectory && !hasFile;

                if (!isEmpty) {
                    File.Delete(gitkeepPath);
                    Debug.Log("<color=#d9534f>Delete</color> .gitkeep in " + path + " .");
                }
            }
        }
    }
}
