# UniMissingReferenceUtils

オブジェクトの参照が Missing Reference になっているかどうかを確認できるクラス

## 使い方

```cs
using Kogane;
using UnityEditor;
using UnityEngine;

public static class Example
{
    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        var gameObject          = Selection.activeGameObject;
        var hasMissingReference = MissingReferenceUtils.HasMissingReference( gameObject );

        Debug.Log( hasMissingReference );
    }
}
```

![2020-09-27_174522](https://user-images.githubusercontent.com/6134875/94360565-30bced80-00e9-11eb-8964-9173342a4768.png)

指定したゲームオブジェクトのいずれかのコンポーネントのオブジェクト参照が  
Missing になっているかどうかを確認できます  
