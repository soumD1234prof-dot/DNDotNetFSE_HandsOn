import './App.css';

function App() {
    const element = "Office Space";

    const jsxatt = <img src="/office_space.jpeg" width="25%" height="25%" alt="Office Space" />;

    const ItemName = { Name: "DBS", Rent: 50000, Address: 'Chennai' };

    let colors = [];
    if (ItemName.Rent <= 60000) {
        colors.push('textRed');
    }
    else {
        colors.push('textGreen');
    }

    const officeList = [
        { Name: "DBS", Rent: 50000, Address: 'Chennai' },
        { Name: "WeWork", Rent: 75000, Address: 'Bangalore' },
        { Name: "CoWorkHub", Rent: 45000, Address: 'Mumbai' },
        { Name: "SmartOffice", Rent: 62000, Address: 'Pune' }
    ];

    return (
        <div className='App'>
          <div className='content'>  
            <h1>{element} , at Affordable Range</h1>
            {jsxatt}
            
            <div className="office-details">
                <h1>Name: {ItemName.Name}</h1>
                <h3 className={colors[0]}>Rent: Rs. {ItemName.Rent}</h3>
                <h3>Address: {ItemName.Address}</h3>
            </div>

            <hr />

            <h1>All Available Office Spaces</h1>
            <ul className="office-list">
                {officeList.map((item, index) => {
                    let rentColor = item.Rent <= 60000 ? 'textRed' : 'textGreen';
                    return (
                        <li key={index}>
                            <h3>Name: {item.Name}</h3>
                            <h3 className={rentColor}>Rent: Rs. {item.Rent}</h3>
                            <h3>Address: {item.Address}</h3>
                        </li>
                    );
                })}
            </ul>
        </div>
    </div>
);
}

export default App;