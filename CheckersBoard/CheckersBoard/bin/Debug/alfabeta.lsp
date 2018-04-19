(Load 'funcionesDamas.lsp)
(setq in (open "data/in.txt"))
(setq depth (read-from-string (read-line in)))
(setq st (read-from-string (read-line in)))
(close in)
(minimax-ab st depth t)
(with-open-file (str "data/out.txt"
                     :direction :output
                     :if-exists :supersede
                     :if-does-not-exist :create)
  (format str (write-to-string (fourth bm))) )
