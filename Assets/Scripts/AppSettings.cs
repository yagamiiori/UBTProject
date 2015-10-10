using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// LINQ to XML�N���X
/// <para>�@LINQ to XML�ɂ��xml���̃f�[�^�𑀍삷��B</para>
/// </summary>
public class AppSettings : MonoBehaviour
{
    /// <summary>�}�l�[�W���[�R���|</summary>
    private GameManager gameManager;
    /// <summary>���[�U��</summary>
    private string userName;
    /// <summary>GUID</summary>
    private string guid;
    /// <summary>�Q�[������</summary>
    private int language;
    /// <summary>���j�b�gID</summary>
    private int[] unitidInXml = new int[16];
    /// <summary>�N���X</summary>
    private int[] classidInXml = new int[16];
    /// <summary>���j�b�g�ɂ������O</summary>
    private string[] unitNameInXml = new string[16];
    /// <summary>�A�r���e�B</summary>
    private int[] abilityInXml = new int[16];
    /// <summary>�G�������g</summary>
    private int[] elementInXml = new int[16];

    /// <summary>�R���X�^���g</summary>
    public AppSettings() { }

    void Start()
    {
        // �}�l�[�W���R���|�擾
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        string xmlFile = "var.xml";
        if (false == System.IO.File.Exists(xmlFile))
        {
            // XML�t�@�C�����Ȃ���΍쐬����
            CreateXmlFile();
        }

        UserStatusLoadFromXml();
        UnitStateLoadFromXml();
        UnitStateSetFromXml();
    }

    /// <summary>
    /// GUID��r���\�b�h
    /// <para>�@Login�V�[���ɂē��͂��ꂽGUID��xml�ɕۑ����ꂽGUID���r���A</para>
    /// <para>�@��v�����true���A�s��v�ł����false��Ԃ��B</para>
    /// </summary>
    /// <param name="inputGuidString"></param>
    /// <returns>GUID�̔�r����</returns>
    public bool CompareGuid(string inputGuidString)
    {
        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in doc.Elements("UserParams")
                    select new
                    {
                        // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                        _guid = (string)p.Element("Guid")
                    };

        // xml���v�f���擾����
        foreach (var elem in query)
        {
            guid = elem._guid;
        }

        bool result = false;
        if (inputGuidString == guid)
        {
            // ���͂��ꂽGUID��XML��GUID����v����ꍇ��true��Ԃ�
            result = true;
        }
        return result;
    }

    /// <summary>
    /// ���j�b�g���X�g�L�����胁�\�b�h
    /// <para>�@���j�b�g���XML�ɑ��݂��邩�ۂ����肷��B</para>
    /// <para>�@���݂����Login�V�[���ȍ~�̓��r�[�ɔ�΂��A���݂��Ȃ����UnitSelect�V�[���֔�΂��B</para>
    /// </summary>
    /// <returns>GUID�̔�r����</returns>
    public bool JudgeUnitExistInXml()
    {
        // �}�l�[�W���R���|�擾
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in doc.Elements("UnitStatus_0")
                    select new
                    {
                        // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                        _unitid = (string)p.Element("UnitID")
                    };

        // xml���v�f���擾����
        int unitIDinXML = 0;
        int NON_VALUE = 99;
        foreach (var elem in query)
        {
            unitIDinXML = int.Parse(elem._unitid);
        }

        bool result = false;
        if (NON_VALUE != unitIDinXML)
        {
            // XML���擾�������j�b�gID�������l(99)�łȂ���΃��j�b�g���L��Ɣ��f��true��Ԃ�
            result = true;
        }
        return result;
    }

    /// <summary>
    /// GUID�t�B�[���h�ݒ胁�\�b�h
    /// <para>�@GUID��xml���擾���ALogin�V�[����GUID�t�B�[���h�ɐݒ肷�邽��</para>
    /// <para>�@�R�[�������\�b�h��GUID�l��Ԃ��B</para>
    /// </summary>
    public string GuidSetForInputFieldInLogin()
    {
        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in doc.Elements("UserParams")
                    select new
                    {
                        // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                        _guid = (string)p.Element("Guid")
                    };

        // xml���v�f���擾����
        foreach (var elem in query)
        {
            guid = elem._guid;
        }
        return guid;
    }

    /// <summary>
    /// ���[�U�֘A�p�����[�^�擾���\�b�h
    /// <para>�@���[�U����GUID�����[�U�֘A�̃p�����[�^��xml���擾����B</para>
    /// </summary>
    public void UserStatusLoadFromXml()
    {
        // �}�l�[�W���R���|���擾
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in doc.Elements("UserParams")
        select new
        {
            // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
            _username = (string)p.Element("UserName"),
            _guid = (string)p.Element("Guid")
        };

        // xml���v�f���擾����
        foreach (var elem in query)
        {
            userName = elem._username;
            guid = elem._guid;
        }

        // xml���擾�������[�U�[����GUID���Q�[���}�l�[�W���[�R���|�ɐݒ肷��
        gameManager.userName = userName;
        gameManager.userGuid = guid;
    }

    /// <summary>
    /// ���j�b�g���X�g�擾���\�b�h
    /// <para>�@���j�b�g���X�g��xml���擾����B</para>
    /// <para>�@UnitStateSetFromXml�ƃZ�b�g�Ŏg�p����B</para>
    /// </summary>
    public void UnitStateLoadFromXml()
    {
        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        for (int i = 0; 16 > i; i++)
        {
            // �v�f�ɑ΂���N�G�����쐬
            var query0 = from p
                            in doc.Elements("UnitStatus_" + i.ToString())
                         select new
                         {
                             // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                             _unitId = (int)p.Element("UnitID"),
                             _unitClass = (int)p.Element("UnitClass"),
                             _unitName = (string)p.Element("UnitName"),
                             _unitAbility = (int)p.Element("UnitAbility1"),
                             _unitElement = (int)p.Element("UnitElement")
                         };
            // xml���v�f���擾����
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
    /// ���j�b�g���X�g�ݒ胁�\�b�h
    /// <para>�@���j�b�g���X�g�擾���\�b�h�iUnitStateLoadFromXml�j��xml���擾����</para>
    /// <para>�@���j�b�g����G�������g�����A�Q�[���}�l�[�W���[���̃��j�b�g���X�g�ɒǉ�����B</para>
    /// <para>�@�܂��A���j�b�gGO���쐬��UnitState�R���|���̃t�B�[���h�ւ̐ݒ���s���B</para>
    /// <para>�@UnitStateLoadFromXml�ƃZ�b�g�Ŏg�p����B</para>
    /// </summary>
    public void UnitStateSetFromXml()
    {
        // �}�l�[�W���R���|���擾
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int i = 0; 16 > i; i++)
        {
            if (99 == unitidInXml[0])
            {
                // ���j�b�g���X�g���G���v�e�B(��)�̏ꍇ�͏I������
                return;
            }

            // ���j�b�g�X�e�[�g�pGO�̃C���X�^���X���ƃR���|�擾
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
    /// xml�t�@�C���������\�b�h
    /// <para>�@�擾����xml�����݂��Ȃ��ꍇ�ɐ������s�����\�b�h�B</para>
    /// </summary>
    public void CreateXmlFile()
    {
        // xml�C���X�^���g���쐬
        XmlDocument document = new XmlDocument();
        XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = document.CreateElement("UBTProject");  // ���[�g�v�f
        document.AppendChild(declaration);                       // �w�肵���m�[�h���q�m�[�h�Ƃ��Ēǉ�
        document.AppendChild(root);

        // ���[�U�[���̗v�f���쐬
        XmlElement elementUserPrm = document.CreateElement("UserParams");
        root.AppendChild(elementUserPrm);
        XmlElement userName = document.CreateElement("UserName");
        userName.InnerText = "NONE";
        elementUserPrm.AppendChild(userName);
        XmlElement guID = document.CreateElement("Guid");
        guID.InnerText = "NONE";
        elementUserPrm.AppendChild(guID);

        // ���j�b�g���X�g�̗v�f���쐬
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
        // �t�@�C���֕ۑ�����
        document.Save("var.xml");
    }
}
