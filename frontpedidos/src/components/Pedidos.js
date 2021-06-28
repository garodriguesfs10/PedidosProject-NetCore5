import React, { useState, useEffect } from 'react'
import Homescreen from './Homescreen'
import { Container, Table } from 'react-bootstrap'
import axios from 'axios'
import PedidoItem from './PedidoItem'


const Pedidos = () => {

    const [pedidos, setPedidos] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(true);

    useEffect(() => {
        async function GetData() {
            try {
                var { data } = await axios.get('https://localhost:44303/api/Pedidos');
                console.log(JSON.stringify(data));
                if (data) {
                    setPedidos(data);
                    setLoading(false);
                    setError(false);
                }
            } catch {
                setLoading(false);
                setError(true);
            }

        }
        GetData();

    }, [])

    return (
        <>
            <Homescreen />
            <Container>
                {loading ? "Carregando..." : error ? "Infelizmente ocorreu um erro ao buscar as informações, tente novamente mais tarde." :
                    <>
                        <Table bordered hover>
                            <thead>
                                <tr>
                                    <th>Status</th>
                                    <th>CPF do Cliente</th>
                                    <th>Nº da venda</th>
                                    <th>Desconto</th>
                                    <th>Frete</th>
                                    <th>Subtotal</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                {pedidos.map((e, i) => (
                                    <PedidoItem key={i} pedido={e} />
                                ))}
                            </tbody>
                        </Table>
                    </>}
            </Container>
        </>

    )
}


export default Pedidos