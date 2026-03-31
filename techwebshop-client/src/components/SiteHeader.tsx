function SiteHeader() {

    const style = {
            backgroundColor: "#222"
        }

    return(
        <div style={style}>    
            <nav className="primary-nav">
                <a href="#">TechWebShop</a>
                <div className="nav-menu">
                    <a href="#">iPhone</a>
                    <a href="#">Mac</a>
                    <a href="#">iPad</a>
                    <a href="#">AirPods</a> 
                    
                </div>
            </nav>
        </div>  
    )

     

}

export default SiteHeader