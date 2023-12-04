
package org.datacontract.schemas._2004._07.osmroutingclient;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the org.datacontract.schemas._2004._07.osmroutingclient package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _ArrayOfArrayOfPosition_QNAME = new QName("http://schemas.datacontract.org/2004/07/OSMRoutingClient", "ArrayOfArrayOfPosition");
    private final static QName _ArrayOfPosition_QNAME = new QName("http://schemas.datacontract.org/2004/07/OSMRoutingClient", "ArrayOfPosition");
    private final static QName _Position_QNAME = new QName("http://schemas.datacontract.org/2004/07/OSMRoutingClient", "Position");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: org.datacontract.schemas._2004._07.osmroutingclient
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link ArrayOfArrayOfPosition }
     * 
     */
    public ArrayOfArrayOfPosition createArrayOfArrayOfPosition() {
        return new ArrayOfArrayOfPosition();
    }

    /**
     * Create an instance of {@link ArrayOfPosition }
     * 
     */
    public ArrayOfPosition createArrayOfPosition() {
        return new ArrayOfPosition();
    }

    /**
     * Create an instance of {@link Position }
     * 
     */
    public Position createPosition() {
        return new Position();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfArrayOfPosition }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ArrayOfArrayOfPosition }{@code >}
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/OSMRoutingClient", name = "ArrayOfArrayOfPosition")
    public JAXBElement<ArrayOfArrayOfPosition> createArrayOfArrayOfPosition(ArrayOfArrayOfPosition value) {
        return new JAXBElement<ArrayOfArrayOfPosition>(_ArrayOfArrayOfPosition_QNAME, ArrayOfArrayOfPosition.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfPosition }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ArrayOfPosition }{@code >}
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/OSMRoutingClient", name = "ArrayOfPosition")
    public JAXBElement<ArrayOfPosition> createArrayOfPosition(ArrayOfPosition value) {
        return new JAXBElement<ArrayOfPosition>(_ArrayOfPosition_QNAME, ArrayOfPosition.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Position }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link Position }{@code >}
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/OSMRoutingClient", name = "Position")
    public JAXBElement<Position> createPosition(Position value) {
        return new JAXBElement<Position>(_Position_QNAME, Position.class, null, value);
    }

}
