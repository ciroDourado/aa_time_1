namespace Tabelas {

public interface IHasher {

	void Set(int capacidade);
	int  Indexar(byte[] bytes);

} // interface IHasher

} // namespace Tabelas
