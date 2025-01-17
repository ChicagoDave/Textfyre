﻿using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using Cjc.SilverFyre;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace ShadowWP7.SavedGames
{
	public static class ExtensionMethods
	{
		public static void SaveProgress( this SavedGameSlot savedGameSlot, IsolatedStorageFile file, string lastCommand, string title, string time, string score, StoryHistoryItem historyItem )
		{
			var slotName = savedGameSlot.SlotName;

			if ( file.DirectoryExists( slotName ) )
			{
				if ( savedGameSlot.Game != null && savedGameSlot.Game.Index != null )
				{
					var progressFile = FilePath( slotName, savedGameSlot.Game.ProgressFile );

					if ( file.FileExists( progressFile ) )
					{
						// Copy progress file content to archive file
						using ( var archive = file.CreateFile( FilePath( slotName, savedGameSlot.Game.ArchiveFile() ) ) )
						{
							using ( var current = file.OpenFile( FilePath( slotName, savedGameSlot.Game.ProgressFile ), System.IO.FileMode.Open ) )
							{
								var lastHistoryItem = StoryHistoryItem.FromXml( XElement.Load( current ) );
								lastHistoryItem.SetCommand( lastCommand );

								lastHistoryItem.ToXml().Save( archive );
							}
						}

						file.DeleteFile( progressFile );
					}
				}
			}
			else
			{
				file.CreateDirectory( slotName );
			}

			savedGameSlot.Game.Update( title, time, score );

			// Copy new content to new current progress file
			using ( var progressFileStream = file.CreateFile( FilePath( slotName, savedGameSlot.Game.ProgressFile ) ) )
			{
				historyItem.ToXml().Save( progressFileStream );
			}
		}

		public static System.IO.Stream LoadProgress( this SavedGameSlot savedGameSlot, IsolatedStorageFile file, int? turn = null )
		{
			if ( savedGameSlot.Game != null && ( !turn.HasValue || turn.Value <= savedGameSlot.Game.Turn ) )
			{
				var slotName = savedGameSlot.SlotName;

				var progressFile = ( turn.HasValue && turn.Value < savedGameSlot.Game.Turn )
					? savedGameSlot.Game.ArchiveFile( turn.Value )
					: savedGameSlot.Game.ProgressFile;

				var progressFilePath = FilePath( slotName, progressFile );

				if ( file.FileExists( progressFilePath ) ) return file.OpenFile( progressFilePath, System.IO.FileMode.Open );
			}

			return null;
		}

		public static System.IO.Stream GetLoadGameStream( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			System.Diagnostics.Debug.WriteLine( "Getting load game stream from {0}", savedGameSlot.SlotName );

			var slotName = savedGameSlot.SlotName;

			return savedGameSlot.HasGameFile( file )
				? file.OpenFile( FilePath( slotName, savedGameSlot.GameFile ), System.IO.FileMode.Open )
				: null;
		}

		public static System.IO.Stream GetSaveGameStream( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			System.Diagnostics.Debug.WriteLine( "Getting save game stream from {0}", savedGameSlot.SlotName );

			var slotName = savedGameSlot.SlotName;

			return file.CreateFile( FilePath( slotName, savedGameSlot.GameFile ) );
		}

		public static bool HasProgressFile( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			return ( savedGameSlot.ProgressFile != null )
				? file.FileExists( FilePath( savedGameSlot.SlotName, savedGameSlot.ProgressFile ) )
				: false;
		}

		public static bool HasGameFile( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			return ( savedGameSlot.GameFile != null )
				? file.FileExists( FilePath( savedGameSlot.SlotName, savedGameSlot.GameFile ) )
				: false;
		}

		public static void DeleteProgress( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			var slotName = savedGameSlot.SlotName;

			if ( file.DirectoryExists( slotName ) )
			{
				foreach ( var f in file.GetFileNames( FilePath( slotName, "*" ) ) )
				{
					file.DeleteFile( FilePath( slotName, f ) );
				}
			}
		}

		public static void DeleteOldGames( this SavedGameSlot savedGameSlot, IsolatedStorageFile file )
		{
			var slotName = savedGameSlot.SlotName;

			foreach ( var f in file.GetFileNames( FilePath( slotName, "Game_*.*" ) ).Where( f => f != savedGameSlot.GameFile ) )
			{
				file.DeleteFile( FilePath( slotName, f ) );
			}
		}

		private static string FilePath( string path1, string path2 )
		{
			return System.IO.Path.Combine( path1, path2 );
		}
	}
}