import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faThumbsDown, faThumbsUp } from '@fortawesome/free-solid-svg-icons'

const PedidoItem = ({ pedido }) => {

    var status = pedido.status === "APROVADO" ? faThumbsUp : faThumbsDown;
    var classStatus = pedido.status === "APROVADO" ? "alert alert-success" : "alert alert-danger";
    return (
        <>
            <tr className={classStatus}>
                <td >   <FontAwesomeIcon icon={status} /> {pedido.status}</td>
                <td>   {pedido.cpfCliente}</td>
                <td>   {pedido.numeroVenda}</td>
                <td>   R${pedido.desconto}</td>
                <td>   R${pedido.frete}</td>
                <td>   R${pedido.subtotal}</td>
                <td>   R${pedido.total}</td>
            </tr>

        </>

    )
}


export default PedidoItem