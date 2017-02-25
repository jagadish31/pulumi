// Copyright 2016 Pulumi, Inc. All rights reserved.

package testutil

import (
	"github.com/pulumi/coconut/pkg/diag"
)

// TestDiagSink suppresses message output, but captures them, so that they can be compared to expected results.
type TestDiagSink struct {
	Pwd      string
	sink     diag.Sink
	messages map[diag.Category][]string
}

func NewTestDiagSink(pwd string) *TestDiagSink {
	return &TestDiagSink{
		Pwd: pwd,
		sink: diag.DefaultSink(diag.FormatOptions{
			Pwd: pwd,
		}),
		messages: make(map[diag.Category][]string),
	}
}

func (d *TestDiagSink) Count() int            { return d.Infos() + d.Errors() + d.Warnings() }
func (d *TestDiagSink) Infos() int            { return len(d.InfoMsgs()) }
func (d *TestDiagSink) InfoMsgs() []string    { return d.messages[diag.Info] }
func (d *TestDiagSink) Errors() int           { return len(d.ErrorMsgs()) }
func (d *TestDiagSink) ErrorMsgs() []string   { return d.messages[diag.Error] }
func (d *TestDiagSink) Warnings() int         { return len(d.WarningMsgs()) }
func (d *TestDiagSink) WarningMsgs() []string { return d.messages[diag.Warning] }
func (d *TestDiagSink) Success() bool         { return d.Errors() == 0 }

func (d *TestDiagSink) Infof(dia *diag.Diag, args ...interface{}) {
	d.messages[diag.Info] = append(d.messages[diag.Info], d.Stringify(dia, diag.Info, args...))
}

func (d *TestDiagSink) Errorf(dia *diag.Diag, args ...interface{}) {
	d.messages[diag.Error] = append(d.messages[diag.Error], d.Stringify(dia, diag.Error, args...))
}

func (d *TestDiagSink) Warningf(dia *diag.Diag, args ...interface{}) {
	d.messages[diag.Warning] = append(d.messages[diag.Warning], d.Stringify(dia, diag.Warning, args...))
}

func (d *TestDiagSink) Stringify(dia *diag.Diag, cat diag.Category, args ...interface{}) string {
	return d.sink.Stringify(dia, cat, args...)
}

func (d *TestDiagSink) StringifyLocation(doc *diag.Document, loc *diag.Location) string {
	return d.sink.StringifyLocation(doc, loc)
}
