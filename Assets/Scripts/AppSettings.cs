using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// LINQ to XMLクラス
/// <para>　LINQ to XMLによりxml内のデータを操作する。</para>
/// </summary>
public class AppSettings : MonoBehaviour
{
    /// <summary>マネージャーコンポ</summary>
    private GameManager gameManager;
    /// <summary>ユーザ名</summary>
    private string userName;
    /// <summary>GUID</summary>
    private string guid;
    /// <summary>ゲーム言語</summary>
    private int language;
    /// <summary>ユニットID</summary>
    private int[] unitidInXml = new int[16];
    /// <summary>クラス</summary>
    private int[] classidInXml = new int[16];
    /// <summary>ユニットにつけた名前</summary>
    private string[] unitNameInXml = new string[16];
    /// <summary>アビリティ</summary>
    private int[] abilityInXml = new int[16];
    /// <summary>エレメント</summary>
    private int[] elementInXml = new int[16];

    /// <summary>コンスタント</summary>
    public AppSettings() { }

    void Start()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        string xmlFile = "var.xml";
        if (false == System.IO.File.Exists(xmlFile))
        {
            // XMLファイルがなければ作成する
            CreateXmlFile();
        }

        UserStatusLoadFromXml();
        UnitStateLoadFromXml();
        UnitStateSetFromXml();
    }

    /// <summary>
    /// GUID比較メソッド
    /// <para>　Loginシーンにて入力されたGUIDとxmlに保存されたGUIDを比較し、</para>
    /// <para>　一致すればtrueを、不一致であればfalseを返す。</para>
    /// </summary>
    /// <param name="inputGuidString"></param>
    /// <returns>GUIDの比較結果</returns>
    public bool CompareGuid(string inputGuidString)
    {
        // xmlファイルを取得
        XElement doc = XElement.Load("var.xml");

        // 要素に対するクエリを作成
        var query = from p in doc.Elements("UserParams")
                    select new
                    {
                        // 各要素とそれに対応する変数を設定
                        _guid = (string)p.Element("Guid")
                    };

        // xmlより要素を取得する
        foreach (var elem in query)
        {
            guid = elem._guid;
        }

        bool result = false;
        if (inputGuidString == guid)
        {
            // 入力されたGUIDとXMLのGUIDが一致する場合はtrueを返す
            result = true;
        }
        return result;
    }

    /// <summary>
    /// ユニットリスト有無判定メソッド
    /// <para>　ユニット情報がXMLに存在するか否か判定する。</para>
    /// <para>　存在すればLoginシーン以降はロビーに飛ばし、存在しなければUnitSelectシーンへ飛ばす。</para>
    /// </summary>
    /// <returns>GUIDの比較結果</returns>
    public bool JudgeUnitExistInXml()
    {
        // マネージャコンポ取得
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // xmlファイルを取得
        XElement doc = XElement.Load("var.xml");

        // 要素に対するクエリを作成
        var query = from p in doc.Elements("UnitStatus_0")
                    select new
                    {
                        // 各要素とそれに対応する変数を設定
                        _unitid = (string)p.Element("UnitID")
                    };

        // xmlより要素を取得する
        int unitIDinXML = 0;
        int NON_VALUE = 99;
        foreach (var elem in query)
        {
            unitIDinXML = int.Parse(elem._unitid);
        }

        bool result = false;
        if (NON_VALUE != unitIDinXML)
        {
            // XMLより取得したユニットIDが初期値(99)でなければユニット情報有りと判断しtrueを返す
            result = true;
        }
        return result;
    }

    /// <summary>
    /// GUIDフィールド設定メソッド
    /// <para>　GUIDをxmlより取得し、LoginシーンのGUIDフィールドに設定するため</para>
    /// <para>　コール元メソッドへGUID値を返す。</para>
    /// </summary>
    public string GuidSetForInputFieldInLogin()
    {
        // xmlファイルを取得
        XElement doc = XElement.Load("var.xml");

        // 要素に対するクエリを作成
        var query = from p in doc.Elements("UserParams")
                    select new
                    {
                        // 各要素とそれに対応する変数を設定
                        _guid = (string)p.Element("Guid")
                    };

        // xmlより要素を取得する
        foreach (var elem in query)
        {
            guid = elem._guid;
        }
        return guid;
    }

    /// <summary>
    /// ユーザ関連パラメータ取得メソッド
    /// <para>　ユーザ名やGUID等ユーザ関連のパラメータをxmlより取得する。</para>
    /// </summary>
    public void UserStatusLoadFromXml()
    {
        // マネージャコンポを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // xmlファイルを取得
        XElement doc = XElement.Load("var.xml");

        // 要素に対するクエリを作成
        var query = from p in doc.Elements("UserParams")
        select new
        {
            // 各要素とそれに対応する変数を設定
            _username = (string)p.Element("UserName"),
            _guid = (string)p.Element("Guid")
        };

        // xmlより要素を取得する
        foreach (var elem in query)
        {
            userName = elem._username;
            guid = elem._guid;
        }

        // xmlより取得したユーザー名とGUIDをゲームマネージャーコンポに設定する
        gameManager.userName = userName;
        gameManager.userGuid = guid;
    }

    /// <summary>
    /// ユニットリスト取得メソッド
    /// <para>　ユニットリストをxmlより取得する。</para>
    /// <para>　UnitStateSetFromXmlとセットで使用する。</para>
    /// </summary>
    public void UnitStateLoadFromXml()
    {
        // xmlファイルを取得
        XElement doc = XElement.Load("var.xml");

        for (int i = 0; 16 > i; i++)
        {
            // 要素に対するクエリを作成
            var query0 = from p
                            in doc.Elements("UnitStatus_" + i.ToString())
                         select new
                         {
                             // 各要素とそれに対応する変数を設定
                             _unitId = (int)p.Element("UnitID"),
                             _unitClass = (int)p.Element("UnitClass"),
                             _unitName = (string)p.Element("UnitName"),
                             _unitAbility = (int)p.Element("UnitAbility1"),
                             _unitElement = (int)p.Element("UnitElement")
                         };
            // xmlより要素を取得する
            foreach (var elem in query0)
            {
                unitidInXml[i] = elem._unitId;
                classidInXml[i] = elem._unitClass;
                unitNameInXml[i] = elem._unitName;
                abilityInXml[i] = elem._unitAbility;
                elementInXml[i] = elem._unitElement;
            }
        }
    }

    /// <summary>
    /// ユニットリスト設定メソッド
    /// <para>　ユニットリスト取得メソッド（UnitStateLoadFromXml）でxmlより取得した</para>
    /// <para>　ユニット名やエレメント等を、ゲームマネージャー内のユニットリストに追加する。</para>
    /// <para>　また、ユニットGOを作成しUnitStateコンポ内のフィールドへの設定も行う。</para>
    /// <para>　UnitStateLoadFromXmlとセットで使用する。</para>
    /// </summary>
    public void UnitStateSetFromXml()
    {
        // マネージャコンポを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int i = 0; 16 > i; i++)
        {
            if (99 == unitidInXml[0])
            {
                // ユニットリストがエンプティ(空)の場合は終了する
                return;
            }

            // ユニットステート用GOのインスタンス化とコンポ取得
            GameObject unitGO = Instantiate(Resources.Load("UnitGO"), transform.position, Quaternion.identity) as GameObject;
            UnitState unitstate = unitGO.GetComponent<UnitState>();
            unitstate.unitID = unitidInXml[i];
            unitstate.classType = classidInXml[i];
            unitstate.unitName = unitNameInXml[i];
            unitstate.ability_A = abilityInXml[i];
            unitstate.element = elementInXml[i];
            unitGO.transform.parent = gameManager.transform;
            gameManager.unitStateList.Add(unitstate);
        }
    }

        /// <summary>
    /// xmlファイル生成メソッド
    /// <para>　取得するxmlが存在しない場合に生成を行うメソッド。</para>
    /// </summary>
    public void CreateXmlFile()
    {
        // xmlインスタントを作成
        XmlDocument document = new XmlDocument();
        XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = document.CreateElement("UBTProject");  // ルート要素
        document.AppendChild(declaration);                       // 指定したノードを子ノードとして追加
        document.AppendChild(root);

        // ユーザー情報の要素を作成
        XmlElement elementUserPrm = document.CreateElement("UserParams");
        root.AppendChild(elementUserPrm);
        XmlElement userName = document.CreateElement("UserName");
        userName.InnerText = "NONE";
        elementUserPrm.AppendChild(userName);
        XmlElement guID = document.CreateElement("Guid");
        guID.InnerText = "NONE";
        elementUserPrm.AppendChild(guID);

        // ユニットリストの要素を作成
        for (int i = 0; 16 > i; i++)
        {
            XmlElement elementUnitSts0 = document.CreateElement("UnitStatus_" + i.ToString());
            root.AppendChild(elementUnitSts0);
            XmlElement UnitID_0 = document.CreateElement("UnitID");
            UnitID_0.InnerText = "99";
            elementUnitSts0.AppendChild(UnitID_0);
            XmlElement UnitClass_0 = document.CreateElement("UnitClass");
            UnitClass_0.InnerText = "99";
            elementUnitSts0.AppendChild(UnitClass_0);
            XmlElement UnitName_0 = document.CreateElement("UnitName");
            UnitName_0.InnerText = "NONE";
            elementUnitSts0.AppendChild(UnitName_0);
            XmlElement UnitAbility1_0 = document.CreateElement("UnitAbility1");
            UnitAbility1_0.InnerText = "99";
            elementUnitSts0.AppendChild(UnitAbility1_0);
            XmlElement UnitAbility2_0 = document.CreateElement("UnitAbility2");
            UnitAbility2_0.InnerText = "99";
            elementUnitSts0.AppendChild(UnitAbility2_0);
            XmlElement UnitElement_0 = document.CreateElement("UnitElement");
            UnitElement_0.InnerText = "99";
            elementUnitSts0.AppendChild(UnitElement_0);
        }
        // ファイルへ保存する
        document.Save("var.xml");
    }
}
