using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
public class XmlManager : MonoBehaviour
{
    /// <summary>�}�l�[�W���[�R���|</summary>
    private GameManager gameManager;
    /// <summary>�Q�[������</summary>
    private int language;
    /// <summary>XML����ǂݏo�������j�b�gID</summary>
    private int[] unitidInXml = new int[16];
    /// <summary>XML����ǂݏo�����N���X</summary>
    private int[] classidInXml = new int[16];
    /// <summary>XML����ǂݏo�������j�b�g��</summary>
    private string[] unitNameInXml = new string[16];
    /// <summary>XML����ǂݏo�����A�r���e�B</summary>
    private int[] abilityInXml = new int[16];
    /// <summary>XML����ǂݏo�����G�������g</summary>
    private int[] elementInXml = new int[16];
    /// <summary>���[�j���O�E�B���h�ECanvas</summary>
    private GameObject warningParentGO;
    /// <summary>���[�j���O�E�B���h�E��Text�R���|</summary>
    private Text warningText;
    /// <summary>���[�j���O�E�B���h�E�\���L������t���O</summary>
    private bool IsWindow = false;
    /// <summary>�i���I�u�W�F�N�g�L���i�C���X�y�N�^����i���I�u�W�F�N�g�ł��鎖���������邽�߂ɐݒ�j</summary>
    [SerializeField]
    private bool isDontDestroy = true;

    /// <summary>�R���X�^���g</summary>
    public XmlManager() { }

    void Awake()
    {
        if (isDontDestroy)
        {
            // TODO Tag + FindGameObjectsWithTag�ɂ�錟���łȂ���Ό������Ȃ��B
            // null == Find("Canvas_FadeDisplay")�@�ł͎�����Find�ΏۂɂȂ邽�߁AFind�Ώێ��g�̒��ōs����null�ɂȂ�P�[�X������
            // ���łɃV�[���ɉ�ʃt�F�[�h�I�u�W�F�N�g�����݂���ꍇ�͏d����}�~���邽�ߖ{�I�u�W�F�N�g��j��
            if (1 < GameObject.FindGameObjectsWithTag("XmlManager").Length)
            {
                Destroy(this.gameObject);
                return;
            }
            // �V�[���ɉ�ʃt�F�[�h�I�u�W�F�N�g�����݂��Ȃ��ꍇ�͖{�I�u�W�F�N�g���i���I�u�W�F�N�g�ɂ���
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        // �}�l�[�W���R���|�擾
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // ���[�j���O�E�B���h�E�̐eGO�����[�j���O�E�B���h�E�Ǘ��N���X���擾
        warningParentGO = GameObject.Find("Canvas_WarningWindow").GetComponent<WarningWindowActiveManager>().warningWindowParentGO;

        string xmlFile = "var.xml";
        if (false == System.IO.File.Exists(xmlFile))
        {
            // XML�t�@�C�����Ȃ���΍쐬����
            CreateXmlFile();
        }

        // ���j�b�g���X�g��XML�t�@�C�����擾���A�擾�������j�b�g����GM�ɐݒ肷��
        UnitStateGetFromXml();
        UnitStateSetToGameManager();
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
        XElement document = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in document.Elements("UserParams")
                    select new
                    {
                        // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                        _guid = (string)p.Element("Guid")
                    };

        // xml���v�f���擾����
        string guidInXml = "";
        foreach (var elem in query)
        {
            guidInXml = elem._guid;
        }

        bool result = false;
        if (inputGuidString == guidInXml)
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
        // xml�t�@�C�����擾
        XElement document = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in document.Elements("UnitStatus_0")
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
        XElement document = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in document.Elements("UserParams")
                    select new
                    {
                        // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                        _guid = (string)p.Element("Guid")
                    };

        // xml���v�f���擾����
        string guidInXml = "";
        foreach (var elem in query)
        {
            guidInXml = elem._guid;
        }
        return guidInXml;
    }

    /// <summary>
    /// ���[�U�֘A�p�����[�^�擾���\�b�h
    /// <para>�@Login�V�[���ɂ����ă��[�U����GUID�Ȃǂ̃��[�U�[�֘A����XML���擾���AGM�ɐݒ肷��B</para>
    /// <para>�@�܂��A�ǂݏo�������Ɋe���̐������`�F�b�N���s���B</para>
    /// </summary>
    public bool UserStatusLoadFromXml()
    {
        // xml�t�@�C�����擾
        XElement document = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p in document.Elements("UserParams")
        select new
        {
            // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
            _username = (string)p.Element("UserName"),
            _guid = (string)p.Element("Guid")
        };

        // XML���v�f���擾����
        string guidInXml = "";
        string userNameInXml = "";
        foreach (var elem in query)
        {
            userNameInXml = elem._username;
            guidInXml = elem._guid;
        }

        if (13 <= userNameInXml.Length)
        {
            // ���[�U�[�����s���̏ꍇ
            return false;
        }
        if (36 != guidInXml.Length)
        {
            // GUID���s���̏ꍇ
            return false;
        }

        // XML�t�@�C�����擾�������[�U�[����GUID���Q�[���}�l�[�W���[�R���|�ɐݒ肷��
        gameManager.userName = userNameInXml;
        gameManager.userGuid = guidInXml;

        return true;
    }

    /// <summary>
    /// ���[�U�֘A�p�����[�^�������݃��\�b�h
    /// <para>�@Register�V�[���ɂ����č쐬�������[�U����GUID�̏���XML�ɐݒ肷��B</para>
    /// </summary>
    /// <param name="userName">Register�V�[���œ��͂��ꂽ���[�U�[��</param>
    /// <param name="guid">Register�V�[���Ő������ꂽGUID</param>
    public void UserStatusWriteToXml(string userName, string guid)
    {
        // xml�t�@�C�����擾
        XElement document = XElement.Load("var.xml");

        IEnumerable<XElement> de =
                                   from el in document.Descendants("UserParams") // UserParams�̗v�f����
                                   select el;
        foreach (XElement el in de)
        {
            // UnitStatus_xx�v�f�z���̏���XML�֏�������
            el.Element("UserName").Value = userName;
            el.Element("Guid").Value = guid;
        }
        // �t�@�C���֕ۑ�����
        document.Save("var.xml");
    }

    /// <summary>
    /// ���j�b�g���X�g�擾���\�b�h
    /// <para>�@���j�b�g���X�g��xml���擾����B</para>
    /// <para>�@UnitStateSetFromXml�ƃZ�b�g�Ŏg�p����B</para>
    /// </summary>
    public void UnitStateGetFromXml()
    {
        // xml�t�@�C�����擾
        XElement document = XElement.Load("var.xml");

        for (int i = 0; 16 > i; i++)
        {
            // �v�f�ɑ΂���N�G�����쐬
            var query0 = from p
                            in document.Elements("UnitStatus_" + i.ToString())
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
    public void UnitStateSetToGameManager()
    {
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
    /// XML�������ݐݒ胁�\�b�h
    /// <para>�@UnitSelect�`AbilitySelect�V�[���őI����������(���j�b�g�X�e�[�g)�̏���C�ӂ̉ӏ���XML�֏������ށB</para>
    /// </summary>
    public void UnitStateWriteToXml()
    {
        for (int i = 0; 16 > i; i++)
        {
            if (99 == gameManager.unitStateList[0].unitID)
            {
                // ���j�b�g�����Ȃ��G���v�e�B(��)�̏ꍇ�͏I������
                return;
            }

            // xml�t�@�C�����擾
            XElement document = XElement.Load("var.xml");

            string elm = "UnitStatus_" + i.ToString();
            IEnumerable<XElement> de =
                                       from el in document.Descendants(elm) // UnitStatus_xx�z���̗v�f����
                                       select el;
            foreach (XElement el in de)
            {
                // UnitStatus_xx�v�f�z���̏���XML�֏�������
                el.Element("UnitID").Value = gameManager.unitStateList[i].unitID.ToString();
                el.Element("UnitClass").Value = gameManager.unitStateList[i].classType.ToString();
                el.Element("UnitName").Value = gameManager.unitStateList[i].unitName;
                el.Element("UnitAbility1").Value = gameManager.unitStateList[i].ability_A.ToString();
                el.Element("UnitAbility2").Value = gameManager.unitStateList[i].ability_B.ToString();
                el.Element("UnitElement").Value = gameManager.unitStateList[i].element.ToString();
            }
            // �t�@�C���֕ۑ�����
            document.Save("var.xml");
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
        userName.InnerText = "";
        elementUserPrm.AppendChild(userName);
        XmlElement guID = document.CreateElement("Guid");
        guID.InnerText = "";
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
