import React, { Component } from 'react';
import { connect } from 'react-redux';

//export default connect()(addinvoice);

class AddInvoice extends React.Component {
	render() {
		return (
			<div className="col-9">
				<form className="form-signin">
					<h2 className="form-signin-heading">Add invoice</h2>
					<label htmlFor="invoice-number" className="sr-only">invoice number</label>
					<input type="text" id="invoice-number" className="form-control" placeholder="invoice number" required autoFocus />
					<label htmlFor="inputpassword" className="sr-only">password</label>
					<input type="text" id="invoice-number" className="form-control" placeholder="invoice number" required />
						<div className="checkbox">
							<label><input type="checkbox" value="remember-me" /> remember me</label>
						</div>
					<button className="btn btn-lg btn-primary btn-block" type="submit">Save invoice</button>
				</form>
			</div>
		);
	}
}

export default AddInvoice;
