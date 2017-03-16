using System.Collections.Generic;

namespace DataLayer
{
    //������ ��� ���� ������� �� ������������ ������ � ������� ��������������� �����
    // ����� � ��������� ������� �������� ������
    public interface IOperationLog
    {
        void Add(Operation operation);
        IEnumerable<Operation> Read(int offset, int count);
        IEnumerable<Operation> ReadAll();
    }
}