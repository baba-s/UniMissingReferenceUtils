using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Kogane
{
	public static class MissingReferenceUtils
	{
		public static bool HasMissingReference( GameObject gameObject )
		{
			var components = gameObject
					.GetComponents<Component>()
					.Where( c => c != null )
				;

			foreach ( var c in components )
			{
				var so = new SerializedObject( c );
				var sp = so.GetIterator();

				while ( sp.NextVisible( true ) )
				{
					if ( sp.propertyType != SerializedPropertyType.ObjectReference ) continue;
					if ( sp.objectReferenceValue != null ) continue;
					if ( !sp.hasChildren ) continue;
					var fileId = sp.FindPropertyRelative( "m_FileID" );
					if ( fileId == null ) continue;
					if ( fileId.intValue == 0 ) continue;

					return true;
				}
			}

			return false;
		}
	}
}