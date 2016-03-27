using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Utils
{
	public static class AudioObjectCreator
	{
		[MenuItem("Audio/Create AudioObjects from AudioClips")]
		private static void CreateAudioAssets()
		{
			if(Selection.objects.Length > 0)
			{
				foreach(Object obj in Selection.objects)
				{
					if(obj.GetType() == typeof(AudioClip))
					{
						string path = AssetDatabase.GetAssetPath(obj);

						if(!string.IsNullOrEmpty(path))
						{
							path = Path.ChangeExtension(path, ".asset");

							SerializedObject asset = new SerializedObject(CreateAudioObjectSingleAtPath(path));

							asset.FindProperty("audioClip").objectReferenceValue = obj;
							asset.ApplyModifiedProperties();
							asset.Dispose();
						}
					}
				}

				AssetDatabase.SaveAssets();
			}
		}

		[MenuItem("Audio/Group AudioObjects")]
		private static void CreateAudioAssetGroups()
		{
			if(Selection.objects.Length > 0)
			{
				List<AudioObjectSingle> targets = new List<AudioObjectSingle>();

				foreach(Object obj in Selection.objects)
				{
					if(obj.GetType() == typeof(AudioObjectSingle))
					{
						targets.Add(obj as AudioObjectSingle);
					}
				}

				if(targets.Count > 0)
				{
					string path = AssetDatabase.GetAssetPath(targets[0]);

					if(!string.IsNullOrEmpty(path))
					{
						int lastIndex = path.LastIndexOf(Path.DirectorySeparatorChar);

						if(lastIndex <= 0)
						{
							lastIndex = path.LastIndexOf(Path.AltDirectorySeparatorChar);
						}

						if(lastIndex > 0)
						{
							path = path.Substring(0, lastIndex + 1);
							path += "New AudioObjectMultiple.asset";
						}
						else
						{
							path = EditorUtility.SaveFilePanelInProject("Create Audio Object Group", "New AudioObjectMultiple", "asset", "Create a new Audio Object Group");

							if(string.IsNullOrEmpty(path))
							{
								return;
							}
						}

						CreateAudioObjectMultipleAtPath(path, targets);
					}
				}
			}
		}

		private static AudioObjectSingle CreateAudioObjectSingleAtPath(string path)
		{
			AudioObjectSingle asset = ScriptableObject.CreateInstance<AudioObjectSingle>();

			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.SaveAssets();

			return asset;
		}

		private static AudioObjectMultiple CreateAudioObjectMultipleAtPath(string path, List<AudioObjectSingle> audioObjects = null)
		{
			AudioObjectMultiple asset = ScriptableObject.CreateInstance<AudioObjectMultiple>();

			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.SaveAssets();

			if(audioObjects != null && audioObjects.Count > 0)
			{
				SerializedObject so = new SerializedObject(asset);
				SerializedProperty element = so.FindProperty("available");

				for(int i = 0; i < audioObjects.Count; i++)
				{
					element.InsertArrayElementAtIndex(i);
					element.GetArrayElementAtIndex(i).objectReferenceValue = audioObjects[i];
				}

				so.ApplyModifiedProperties();
			}

			Selection.activeObject = asset;
			return asset;
		}
	}
}