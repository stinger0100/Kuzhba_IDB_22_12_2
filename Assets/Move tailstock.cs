using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    public GameObject tailstock;    // ������ �����
    public GameObject handle;       // �������� ������ �����
    public Text field;  // ���� � ������������ ������ ����� � ���������� 

    public GameObject tool_hold;            // �����������
    public GameObject handle_transverse;    // ���������� �����
    public GameObject handle_lateral;       // ���������� �����
    public GameObject cartrige;

    // ��������� ������� ������ ����� � �������� ������ �����
    public double start_position_tailstock_x, start_position_tailstock_y, start_position_tailstock_z;
    public double start_position_handle_x, start_position_handle_y, start_position_handle_z;
    public double start_rotation_handle_x, start_rotation_handle_y, start_rotation_handle_z;
    public float rotate_z_prev_1 = 0;

    // ��������� ������� ����������� � ����������, ���������� ��������
    public double start_position_tool_hold_x, start_position_tool_hold_y, start_position_tool_hold_z;
    public double current_position_tool_hold_x_1, current_position_tool_hold_z_1, current_position_tool_hold_x_2, current_position_tool_hold_z_2;
    public double start_rotation_handle_transverse_x, start_rotation_handle_transverse_y, start_rotation_handle_transverse_z;
    public float rotate_x_prev_2 = 0;

    public double start_position_handle_lateral_x, start_position_handle_lateral_y, start_position_handle_lateral_z;
    public double current_position_handle_lateral_x_1, current_position_handle_lateral_z_1, current_position_handle_lateral_x_2, current_position_handle_lateral_z_2;
    public double start_rotation_handle_lateral_x, start_rotation_handle_lateral_y, start_rotation_handle_lateral_z;
    public float rotate_z_prev_3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �����
        start_position_tailstock_x = tailstock.transform.position.x;
        start_position_tailstock_y = tailstock.transform.position.y;
        start_position_tailstock_z = tailstock.transform.position.z;

        start_position_handle_x = handle.transform.position.x;
        start_position_handle_y = handle.transform.position.y;
        start_position_handle_z = handle.transform.position.z;

        start_rotation_handle_x = handle.transform.rotation.x;
        start_rotation_handle_y = handle.transform.rotation.y;
        start_rotation_handle_z = handle.transform.rotation.z;

        // �����������
        start_position_tool_hold_x = tool_hold.transform.position.x;
        start_position_tool_hold_y = tool_hold.transform.position.y;
        start_position_tool_hold_z = tool_hold.transform.position.z;

        current_position_tool_hold_x_1 = tool_hold.transform.position.x;
        current_position_tool_hold_z_1 = tool_hold.transform.position.z;
        current_position_tool_hold_x_2 = tool_hold.transform.position.x;
        current_position_tool_hold_z_2 = tool_hold.transform.position.z;

        // ���������� �������� �����������
        start_rotation_handle_transverse_x = handle_transverse.transform.rotation.x;
        start_rotation_handle_transverse_y = handle_transverse.transform.rotation.y;
        start_rotation_handle_transverse_z = handle_transverse.transform.rotation.z;

        // ���������� �������� �����������
        start_position_handle_lateral_x = handle_lateral.transform.position.x;
        start_position_handle_lateral_y = handle_lateral.transform.position.y;
        start_position_handle_lateral_z = handle_lateral.transform.position.z;

        current_position_handle_lateral_x_1 = handle_lateral.transform.position.x;
        current_position_handle_lateral_z_1 = handle_lateral.transform.position.z;
        current_position_handle_lateral_x_2 = handle_lateral.transform.position.x;
        current_position_handle_lateral_z_2 = handle_lateral.transform.position.z;

        start_rotation_handle_lateral_x = handle_lateral.transform.rotation.x;
        start_rotation_handle_lateral_y = handle_lateral.transform.rotation.y;
        start_rotation_handle_lateral_z = handle_lateral.transform.rotation.z;

    }

    // Update is called once per frame
    void Update()
    {

        /*// �������� �������
        float rotation_speed = 50;
        cartrige.transform.rotation = Quaternion.Slerp(cartrige.transform.rotation, Quaternion.Euler.eulerAngles(0, 0, (float)(100 * Time.deltaTime)), (float)(rotation_speed * Time.deltaTime));
        */

        // ���������� ���������� y ���������� ������ �����
        field.text = $"������� ������ �����: {Math.Round(start_position_tailstock_z - tailstock.transform.position.z, 3)} \n������� ����������� �� X: {Math.Round(start_position_tool_hold_x - tool_hold.transform.position.x, 3)} \n������� ����������� �� Z: {Math.Round(start_position_tool_hold_z - tool_hold.transform.position.z, 3)}";

        // ����������� ������ ����� �� ��� Z
        if (rotate_z_prev_1 < handle.transform.rotation.eulerAngles.z)
        {

            tailstock.transform.position = new Vector3((float)start_position_tailstock_x, (float)start_position_tailstock_y, (float)(start_position_tailstock_z - handle.transform.rotation.eulerAngles.z / 1000));
            handle.transform.position = new Vector3((float)start_position_handle_x, (float)start_position_handle_y, (float)(start_position_handle_z - handle.transform.rotation.eulerAngles.z / 1000));
            rotate_z_prev_1 = handle.transform.rotation.z;

        }

        // ����������� ����������� �� ��� X
        if (rotate_x_prev_2 != handle_transverse.transform.rotation.x)
        {

            tool_hold.transform.position = new Vector3((float)(current_position_tool_hold_x_2 + handle_transverse.transform.rotation.x / 10), (float)start_position_tool_hold_y, (float)current_position_tool_hold_z_2);
            handle_lateral.transform.position = new Vector3((float)(current_position_handle_lateral_x_2 + handle_transverse.transform.rotation.x / 10), (float)start_position_handle_lateral_y, (float)current_position_handle_lateral_z_2);

            // ���������� ����� ����������
            current_position_tool_hold_x_1 = tool_hold.transform.position.x;
            current_position_tool_hold_z_1 = tool_hold.transform.position.z;
            current_position_handle_lateral_x_1 = handle_lateral.transform.position.x;
            current_position_handle_lateral_z_1 = handle_lateral.transform.position.z;

            rotate_x_prev_2 = handle_transverse.transform.rotation.x;

        }

        // ����������� ����������� �� ��� Z
        if (rotate_z_prev_3 != handle_lateral.transform.rotation.z)
        {

            tool_hold.transform.position = new Vector3((float)current_position_tool_hold_x_1, (float)start_position_tool_hold_y, (float)(current_position_tool_hold_z_1 + handle_lateral.transform.rotation.z / 10));
            handle_lateral.transform.position = new Vector3((float)current_position_handle_lateral_x_1, (float)start_position_handle_lateral_y, (float)(current_position_handle_lateral_z_1 + handle_lateral.transform.rotation.z / 10));

            // ���������� ����� ����������
            current_position_tool_hold_x_2 = tool_hold.transform.position.x;
            current_position_tool_hold_z_2 = tool_hold.transform.position.z;
            current_position_handle_lateral_x_2 = handle_lateral.transform.position.x;
            current_position_handle_lateral_z_2 = handle_lateral.transform.position.z;

            rotate_z_prev_3 = handle_lateral.transform.rotation.z;

        }

    }

    // ��������� ������� ������; ���������� ������ ����� � ����������� � �� ���������� � �������� ���������
    public void ButtonClick()  
    {

        tailstock.transform.position = new Vector3((float)start_position_tailstock_x, (float)start_position_tailstock_y, (float)start_position_tailstock_z);
        handle.transform.position = new Vector3((float)start_position_handle_x, (float)start_position_handle_y, (float)start_position_handle_z);
        handle.transform.rotation = Quaternion.Euler((float)start_rotation_handle_x, (float)start_rotation_handle_y, (float)start_rotation_handle_z);

        tool_hold.transform.position = new Vector3((float)start_position_tool_hold_x, (float)start_position_tool_hold_y, (float)start_position_tool_hold_z);
        
        handle_transverse.transform.rotation = Quaternion.Euler((float)start_rotation_handle_transverse_x, (float)start_rotation_handle_transverse_y, (float)start_rotation_handle_transverse_z);

        handle_lateral.transform.position = new Vector3((float)start_position_handle_lateral_x, (float)start_position_handle_lateral_y, (float)start_position_handle_lateral_z);
        handle_lateral.transform.rotation = Quaternion.Euler((float)start_rotation_handle_lateral_x, (float)start_rotation_handle_lateral_y, (float)start_rotation_handle_lateral_z);

    }
}
