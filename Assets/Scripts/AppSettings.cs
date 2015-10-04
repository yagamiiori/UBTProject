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
    private int unitidInXml;
    /// <summary>�N���X</summary>
    private int classidInXml;
    /// <summary>���j�b�g�ɂ������O</summary>
    private string unitNameInXml;
    /// <summary>�A�r���e�B</summary>
    private int abilityInXml;
    /// <summary>�G�������g</summary>
    private int elementInXml;

    /// <summary>�R���X�^���g</summary>
    private AppSettings() { }

    void Start()
    {
        // �}�l�[�W���R���|���擾
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        ReadStartOfUnitListInXml();
    }

    /// <summary>
    /// ���[�U�֘A�p�����[�^�擾���\�b�h
    /// <para>�@���[�U����GUID�����[�U�֘A�̃p�����[�^��xml���擾����B</para>
    /// </summary>
    private void ReadStartOfUserParamInXml()
    {
        
        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        // Elements:�u�q�v�f�v���擾����
        var query = from p in doc.Elements("UserParams")
        select new
        {
            // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
            _username = (string)p.Element("UserName"),
            _guid = (string)p.Element("GUID")
        };

        // xml���v�f���擾����
        foreach (var elem in query)
        {
            userName = elem._username;
            guid = elem._guid;
        }
    }

    /// <summary>
    /// ���j�b�g���X�g�擾���\�b�h
    /// <para>�@���j�b�g���X�g��xml���擾����B</para>
    /// </summary>
    private void ReadStartOfUnitListInXml()
    {
        // xml�t�@�C�����擾
        XElement doc = XElement.Load("var.xml");

        // �v�f�ɑ΂���N�G�����쐬
        var query = from p
                        in doc.Elements("UnitStatus_1")
                        select new
                        {
                            // �e�v�f�Ƃ���ɑΉ�����ϐ���ݒ�
                            _unitId = (int)p.Element("UnitID"),
                            _unitClass = (int)p.Element("UnitClass"),
                            _unitName = (string)p.Element("UnitName"),
                            _unitAbility = (int)p.Element("UnitAbility"),
                            _unitElement = (int)p.Element("UnitElement")
                        };

        // xml���v�f���擾����
        foreach (var elem in query)
        {
            unitidInXml = elem._unitId;
            classidInXml = elem._unitClass;
            unitNameInXml = elem._unitName;
            abilityInXml = elem._unitAbility;
            elementInXml = elem._unitElement;
        }
    }

    /// <summary>
    /// xml���j�b�g���X�g���Q�[���}�l�[�W���[���j�b�g���X�g�ݒ胁�\�b�h
    /// <para>�@xml���擾�������j�b�g���X�g(�G�������g�⃆�j�b�g����)���A</para>
    /// <para>�@�Q�[���}�l�[�W���[���̃��j�b�g���X�g�ɍڂ�������B</para>
    /// </summary>
    private void SettingsUnitListForXml()
    {
    }

        /// <summary>
    /// xml�t�@�C���������\�b�h
    /// <para>�@�擾����xml���Ȃ��ꍇ�ɐ������s�����\�b�h�B</para>
    /// </summary>
    private void CreateXmlFile()
    {
        // xml�C���X�^���g���쐬
        XmlDocument document = new XmlDocument();
        XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = document.CreateElement("root");  // ���[�g�v�f
        document.AppendChild(declaration);                 // �w�肵���m�[�h���q�m�[�h�Ƃ��Ēǉ�
        document.AppendChild(root);

        // �v�f���쐬
        XmlElement element = document.CreateElement("element");
        element.InnerText = "text";                        // �v�f�̓��e
        element.SetAttribute("attribute", "256");          // �v�f�ɑ�����ݒ�
        root.AppendChild(element);

        // �t�@�C���Ƃ��ĕۑ�����
        document.Save("sample.xml");
    }
}
